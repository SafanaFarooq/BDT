Feature: SpecFlowFeature1
	In order to take automation classes
	as a student
	I want to register on the website


Scenario Outline: Submit Student's Registration Form
	Given I have entered FirstName in the <FirstName> field
	And I have entered LastName in the <LastName> field
	And I have entered Email in the <Email> field
	And I have selected my Gender
	And I have entered MobileNumber in the <MobileNumber> field
	And I have selected my DOB from the date picker
	And I have selected Subject to study
	And I have selected my Hobbies
	And I have uploaded my Picture
	And I have entered CurrentAddress in the <CurrentAddress> field
	And I have selected my State
	And I have selected my City
	When I click the Sumit button
	Then Validation <Message> should be displayed

	Examples:
     | FirstName | LastName | Email          | MobileNumber | CurrentAddress | Message                        |
     | Safana    | Farooq   | sf@example.com | 15987456321  | abc street     | Thanks for submitting the form |
	 | Safana    | Farooq   | sf@example.com | 15987456321  |			     | Thanks for submitting the form |
	 | Safana    | Farooq   | sf@example.com |				| abc street     | Practice Form |
	 | Safana    | Farooq   |				 | 15987456321  | abc street     | Practice Form |

	 