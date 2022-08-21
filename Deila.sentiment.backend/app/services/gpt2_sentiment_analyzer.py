from datasets import load_dataset
data_files = {"train":"train.csv", "validate":"validate.csv" }
dataset = load_dataset("deancgarcia/Diversity", data_files=data_files)

import sys
sys.path.append("C:/Users/Dean/Documents/GitHub/DEILA/Deila.sentiment.backend/app/models")
from classification_collator import Gpt2ClassificationCollator
from article_dataset import ArticleDataset
import io
import pandas as pd
import os
import torch
from torch.utils.data import Dataset, DataLoader
from sklearn.metrics import classification_report, accuracy_score
from transformers import (set_seed,
                          TrainingArguments,
                          Trainer,
                          GPT2Config,
                          GPT2Tokenizer,
                          AdamW, 
                          get_linear_schedule_with_warmup,
                          GPT2ForSequenceClassification) 

set_seed(123)
epochs = 4
batch_size = 32
max_length = 60
device = torch.device('cuda' if torch.cuda.is_available() else 'cpu')
model_name_or_path = 'gpt2'
labels_ids = {'neg': 0, 'pos': 1}
n_labels = len(labels_ids)

model_config = GPT2Config.from_pretrained(pretrained_model_name_or_path=model_name_or_path, num_labels=n_labels)
tokenizer = GPT2Tokenizer.from_pretrained(pretrained_model_name_or_path=model_name_or_path)
tokenizer.padding_side = "left"
tokenizer.pad_token = tokenizer.eos_token

model = GPT2ForSequenceClassification.from_pretrained(pretrained_model_name_or_path=model_name_or_path, config=model_config)
model.resize_token_embeddings(len(tokenizer))
model.config.pad_token_id = model.config.eos_token_id
model.to(device)
gpt2_classificaiton_collator = Gpt2ClassificationCollator(use_tokenizer=tokenizer, labels_encoder=labels_ids, max_sequence_len=max_length)
train_dataset = ArticleDataset(datatype='train', use_tokenizer=tokenizer)
train_dataloader = DataLoader(train_dataset, batch_size=batch_size, shuffle=True, collate_fn=gpt2_classificaiton_collator)
valid_dataset =  ArticleDataset(datatype='validate', use_tokenizer=tokenizer)
valid_dataloader = DataLoader(valid_dataset, batch_size=batch_size, shuffle=False, collate_fn=gpt2_classificaiton_collator)


# Adaptive Moment Estimation Optimzer 
#combined advantages of gradient descent with momentum and the RMSProp optimization algorithm
optimizer = AdamW(model.parameters(), lr = 2e-5, eps = 1e-8)

total_steps = len(train_dataloader) * epochs

scheduler = get_linear_schedule_with_warmup(optimizer, num_warmup_steps = 0, num_training_steps = total_steps)


def train(dataloader, optimizer_, scheduler_, device_):
    global model
    predictions_labels = []
    true_labels = []
    total_loss = 0

    model.train()

    for batch in dataloader:
        true_labels += batch['labels'].numpy().flatten().tolist()
        batch = {k:v.type(torch.long).to(device_) for k,v in batch.items()}
        model.zero_grad()
        outputs = model(**batch)
        loss, logits = outputs[:2]
        total_loss += loss.item()
        loss.backward()
        torch.nn.utils.clip_grad_norm_(model.parameters(), 1.0)
        optimizer_.step()
        scheduler_.step()
        logits = logits.detach().cpu().numpy()
        predictions_labels += logits.argmax(axis=-1).flatten().tolist()

    avg_epoch_loss = total_loss / len(dataloader) 
    return true_labels, predictions_labels, avg_epoch_loss

def validation(dataloader, device_):
  global model

  predictions_labels = []
  true_labels = []
  total_loss = 0

  model.eval()

  for batch in dataloader:
    true_labels += batch['labels'].numpy().flatten().tolist()

    batch = {k:v.type(torch.long).to(device_) for k,v in batch.items()}

    with torch.no_grad():        
        outputs = model(**batch)

        loss, logits = outputs[:2]
        
        logits = logits.detach().cpu().numpy()

        total_loss += loss.item()
        
        predict_content = logits.argmax(axis=-1).flatten().tolist()

        predictions_labels += predict_content

  avg_epoch_loss = total_loss / len(dataloader)

  return true_labels, predictions_labels, avg_epoch_loss

def model_classify(zero, init_token):
    #let it train here show it in demo
    global tokenizer
    global model
    model.eval()
    init_id = tokenizer.encode(init_token)
    result = init_id
    init_input = torch.tensor(init_id).unsqueeze(zero).to(device)

    with torch.no_grad():
        output = model(init_input)
        logits = output.logits[:2]
        logits = logits.detach().cpu().numpy()
        print(logits)
        predict_content = logits.argmax(axis=-1).flatten().tolist()
        print(predict_content)

    return logits

for epoch in range(epochs):
    train_labels, train_predict, train_loss = train(train_dataloader, optimizer, scheduler, device)
    train_acc = accuracy_score(train_labels, train_predict)
    valid_labels, valid_predict, val_loss = validation(valid_dataloader, device)
    val_acc = accuracy_score(valid_labels, valid_predict)

print("Model Loaded")
