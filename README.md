# InclusiveLA
This is my project for Inclusive Coding!

# Links
DEI Dataset: https://huggingface.co/datasets/deancgarcia/Diversity <br />
Colab NLP Code: https://colab.research.google.com/drive/1bcbZyo3TVRPt_N8XMAI1kDpPkvidnopS

# Abstract
In 2017 Google published an article titled Attention is
All You Need which described a new network architecture
dubbed the Transformer. From this spurred OpenAIs Generative
Pretrained Transformer 2 (GPT-2). Out of the box the
GPT-2 is pretrained for text generation though with a little
fine-tuning it can be used for various other Natural Language
Processing tasks such as question answering, reading comprehension,
summarization, translation and while text classification
is not a typical use case it can be fine-tuned for this
task as well. I plan to do leverage GPT-2 to perform sentiment 
analysis on Diversity Equity and Inclusion (DEI) related content.

# Introduction 
Studies show that DEI supports growth and innovation in
the workplace (Chaudhry, Paquibut and Tunio, 2021). One
way to help promote and increase DEI in the workplace
is through newsletters/emails and special observances. For
these two tasks it is typical to generate informational artifacts
with content that can unknowingly relay the wrong
sentiment. One way to avoid this situation is by employing
editors and legal advisors to vet and approve content to ensure
they align with the company creed though this can be
time consuming and costly. Time and cost can potentially
be reduced by using a machine learning model trained to
distinguish inclusive text as having either a negative or positive
sentiment. While there have been many studies focused
on sentiment analysis for the most part the publicly available
data-sets used in these studies are ostensibly explicit in nature.
To overcome this hurdle, I plan to create a new data-set
with content that has been published by reputable companies.
I plan to use this data-set to fine-tune a GPT-2 based
model to perform sentiment analysis. The data-set also includes
additional features that I hope can be used for other
purposes in the future. Along with this I plan to create a front end web
application that will allow users to: Add to the DEI dataset by providing 
the link to a web based article. And let users test the sentiment analysis model by inputting text.


<h3>Setup:</h3>
Used this link for initial setup instructions. get into the details of the frontend and backend set ups in relative read me
https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-5.0
