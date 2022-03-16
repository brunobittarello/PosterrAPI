# PosterrAPI
Strider Web Back-end Assessment - 2.3

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