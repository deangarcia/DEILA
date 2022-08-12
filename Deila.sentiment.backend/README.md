<h3>Setup:</h3>
Used this link for initial setup instructions.
https://fastapi.tiangolo.com/tutorial/first-steps/

Reorganized my file system and ran uvicorn app.main:app --reload
once running locally I deployed to azure web app running a python 3.9 runtime stack.

then in configuration I edited the startup general settings value to be gunicorn -w 4 -k uvicorn.workers.UvicornWorker app.main:app
this is different from running locally.

After that you can access the api the same way you have locally. Make sure to set the server name in the config app to the domain of 
of your web app