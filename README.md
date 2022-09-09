# Scoreboard

The solution was supposed to be simple so I made some assumtions that I would clarify with product owner and simplifications in the code that I would implement in the production code. 

- I assumed that Summary would not be formatted as for example string or html, the method returns a list of the objects that could be formatted or displayed on the client side.
- There wasn't any mention about gameId in the instructions, but I think it's the best way to distinguish on which game we are operating - as more than one game could be in progress during the same time.
- The scoreboard collection is not handled by any IoC Container - it's just instantieted in the constructor of the GameService class or injected by the test class. It doesn't change anything in the logic, I didn't want to add additional library configuration file in such simple application.
- The GameService has some validation but quite simple so it wasn't refactored to the separate class.
- Validation messages could be placed in the separate cofiguration - for example if there would be a need to translate them and handle more then one language
- I'm aware that 'this' word is very often redundant - but I really like to use it, the code is more strict in my opinion :)

