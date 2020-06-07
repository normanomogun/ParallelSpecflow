Feature: Login
	Background: 
	Given I am on the execute automation website

@mytag
Scenario Outline: Login To Site Successfully
	Given I am on the login page 
	When I enter <username> and <password>
	When I press login
	Then i should be redirected to the form page 

	Examples: 
	| username | password |
	| Admin    | test1234 |
