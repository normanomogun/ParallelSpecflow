Feature: UserForm
	
	Background: 
	Given I am on the execute automation website

@mytag
Scenario: Fill Form Succcefully
	Given I am on the login page 
	When I enter <username> and <password>
	When I press login
	Then i should be redirected to the form page 
	When I enter the following form details
	| initial | firstname | middlename |
	| b       | billy     | sazu       |

	And I click save on form page 
	Examples: 
	| username | password |
	| Admin    | test1234 |
