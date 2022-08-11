from fastapi import FastAPI

app = FastAPI()


@app.get("/")
async def root():
    return [{"negative": 0.1, "positive": 1}]