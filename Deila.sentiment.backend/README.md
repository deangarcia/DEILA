<h3>Setup:</h3>
Used this link for initial setup instructions.
https://fastapi.tiangolo.com/tutorial/first-steps/

Reorganized my file system and ran uvicorn app.main:app --reload
once running locally I deployed to azure web app running a python 3.9 runtime stack. Deploy by right clicking top most folder
in my case it was deila.sentiment.backend folder then deploy to web app.

then in configuration I edited the startup general settings value to be gunicorn -w 4 -k uvicorn.workers.UvicornWorker app.main:app
this is different from running locally.

After that you can access the api the same way you have locally. Make sure to set the server name in the config app to the domain of 
of your web app

dont have swagger but can test with this since it is only one endpoint http://127.0.0.1:8000/api/v1/sentiment_analysis/?text=positive
