Feature: GithubUsers
Testing Angular app listing GitHub Users, apply filtering and navigate to the User details page when one is selected.

@GithubUsersApp
Scenario: List Github Users
	Given I navigate to the GithubUsers app
	Then I verify a list of Users is displayed

Scenario: Filter Github Users searching for existing User
	Given I navigate to the GithubUsers app
	When I type roland as a searchTerm
	Then search results for the given searchTerm should appear

Scenario: Filter Github Users searching for non-existing User
	Given I navigate to the GithubUsers app
	When I type foobarxx as a searchTerm
	Then no results message is displayed

Scenario: Navigate to User details page
	Given I navigate to the GithubUsers app
	When I type roland as a searchTerm
	And I click on the user card
	Then the User details page is displayed
