# Disclaimer

This project is my test for Strider. The test says it can be done in 8h, I think it is very inaccurate. You need to read all documents, implement a API, validations, tests, DB architecture and documentation for futures features. It is too much. This is what I done in approximately 8h, it is very incomplete for what is asked. Here are the assessments for that dumb test:

[Strider Web Back-end Assessment - 2.3](https://github.com/brunobittarello/PosterrAPI/blob/main/Assessment/Strider%20Web%20Back-end%20Assessment%20-%202.3.pdf)

[Strider Technical Assessment Briefing](https://github.com/brunobittarello/PosterrAPI/blob/main/Assessment/Strider%20Technical%20Assessment%20Briefing.pdf)



Here is the readme asked: 


# PosterrAPI
Strider Web Back-end Assessment - 2.3

dotnet ef migrations add InitialCreate --context SqliteDataContext --output-dir Migrations

 # Planning

 ## Questions

- Will be "reply-to-post" counting for the maximum 5 posts per day?
- Will the user name mentioned couting for the maximum characters in post?

## Details

 - A new tab should be created in front-end to show replies;
 - Add a new property in Post entity to point to the reply post, will work similar as the quote feature;
 - New route to return only replies

 # Critique

 - Finish non-implemented features;
 - Finish to cover all methods and lines in Unit Tests
 - Make Database interation asyincronous;
 - Return validation and erros as a text to give a feedback;
 - Add general exception handle to avoid sending sensitive code stack to front-end;
 - Integration tests;
