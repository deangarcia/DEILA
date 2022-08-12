import sys
from typing import Any
from fastapi import APIRouter, Depends, HTTPException

from app import schemas

router = APIRouter()

@router.get("/", response_model=schemas.Sentiment)
def analyze_sentiment(
    text: str = "",
) -> Any:
    """
    Take in text and run it through the model and return neg pos logits.
    """
    #sentiment = service.analyze_dei_text(text)
    sentiment = schemas.Sentiment()
    sentiment.negative = 400
    sentiment.positive = 700

    return sentiment