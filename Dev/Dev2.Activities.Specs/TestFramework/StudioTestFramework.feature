﻿@TestFramework
Feature: StudioTestFramework
	In order to test workflows in warewolf 
	As a user
	I want to create, edit, delete and update tests in a test window


Background: Setup for workflows for tests
		Given test folder is cleaned	
		And I have "Workflow 1" with inputs as
			| Input Var Name |
			| [[a]]          |
		And "Workflow 1" has outputs as
			| Ouput Var Name  |
			| [[outputValue]] |		
		Given I have "Workflow 2" with inputs as
			| Input Var Name |
			| [[rec().a]]    |
			| [[rec().b]]    |
		And "Workflow 2" has outputs as
			| Ouput Var Name |
			| [[returnVal]]  |
		Given I have "Workflow 3" with inputs as
			| Input Var Name |
			| [[A]]              |
			| [[B]]              |
			| [[C]]              |
		And "Workflow 3" has outputs as
			| Ouput Var Name |
			| [[message]]    |
		Given I have "WorkflowWithTests" with inputs as 
			| Input Var Name |
			| [[input]]      |
		And "WorkflowWithTests" has outputs as
			| Ouput Var Name  |
			| [[outputValue]] |			
		And "WorkflowWithTests" Tests as 
			| TestName | AuthenticationType | Error | TestFailing | TestPending | TestInvalid | TestPassed |
			| Test1    | Windows            | false | false       | false       | false       | true       |
			| Test2    | Windows            | false | true        | false       | false       | false      |
			| Test3    | Windows            | false | false       | false       | true        | false      |
			| Test4    | Windows            | false | false       | true        | false       | false      |

				
@TestFramework
Scenario: Create New Test
	Given the test builder is open with "Workflow 1"	
	And Tab Header is "Workflow 1 - Tests"
	And there are no tests
	When I click New Test
	Then a new test is added
	And Tab Header is "Workflow 1 - Tests *"
	And test name starts with "Test 1"
	And username is blank
	And password is blank
	And inputs are
	| Variable Name | Value |
	| a             |       |
	And outputs as
	| Variable Name | Value |
	| outputValue   |       |
	And save is enabled
	And test status is pending
	And test is enabled
	And Duplicate Test is "Disabled"

@TestFramework
Scenario: Create New Test with Service that as recordset inputs
	Given the test builder is open with "Workflow 2"	
	And Tab Header is "Workflow 2 - Tests"
	And there are no tests
	When I click New Test
	Then a new test is added
	And Tab Header is "Workflow 2 - Tests *"
	And test name starts with "Test 1"
	And username is blank
	And password is blank
	And inputs are
	| Variable Name | Value |
	| rec(1).a      |       |
	| rec(1).b      |       |
	And I update inputs as
	| Variable Name | Value |
	| rec(1).a      | val1  |
	| rec(1).b      |       |
	Then inputs are
	| Variable Name | Value |
	| rec(1).a      | val1  |
	| rec(1).b      |       |
	| rec(2).a      |       |
	| rec(2).b      |       |

@TestFramework
Scenario: Save a New Test
	Given the test builder is open with "Workflow 1"
	And Tab Header is "Workflow 1 - Tests"
	And there are no tests
	And I click New Test
	Then a new test is added
	And Tab Header is "Workflow 1 - Tests *"
	And test name starts with "Test 1"
	And inputs are
	| Variable Name | Value |
	| a             |       |
	And outputs as
	| Variable Name | Value |
	| outputValue   |       |
	And save is enabled
	When I save
	Then Tab Header is "Workflow 1 - Tests"
	And I close the test builder
	When the test builder is open with "Workflow 1"
	Then there are 1 tests
	And "Dummy Test" is selected
	And I select "Test 1"
	And "Test 1" is selected
	And test name starts with "Test 1"
	And inputs are
	| Variable Name | Value |
	| a             |       |
	And outputs as
	| Variable Name | Value |
	| outputValue   |       |
	And save is disabled

@TestFramework
Scenario: Save multiple New Tests Enabled Save after Edit
	Given the test builder is open with "Workflow 1"
	And Tab Header is "Workflow 1 - Tests"
	And there are no tests
	And I click New Test
	Then a new test is added
	And Tab Header is "Workflow 1 - Tests *"
	And test name starts with "Test 1"
	And inputs are
	| Variable Name | Value |
	| a             |       |
	And outputs as
	| Variable Name | Value |
	| outputValue   |       |
	And save is enabled
	When I save
	Then Tab Header is "Workflow 1 - Tests"
	Then there are 1 tests
	And I select "Test 1"
	And "Test 1" is selected
	And test name starts with "Test 1"
	And inputs are
	| Variable Name | Value |
	| a             |       |
	And outputs as
	| Variable Name | Value |
	| outputValue   |       |
	And save is disabled
	And I click New Test
	Then a new test is added
	And Tab Header is "Workflow 1 - Tests *"
	And test name starts with "Test 2"
	And inputs are
	| Variable Name | Value |
	| a             |       |
	And outputs as
	| Variable Name | Value |
	| outputValue   |       |
	And save is enabled
	When I save
	Then Tab Header is "Workflow 1 - Tests"
	When I select "Test 1"
	When I change the test name to "testing2"
	Then "Save" test is visible

@TestFramework
Scenario: Save a New Test fails when workflow deleted
	Given the test builder is open with "Workflow 1"
	And Tab Header is "Workflow 1 - Tests"
	And there are no tests
	And I click New Test
	Then a new test is added
	And Tab Header is "Workflow 1 - Tests *"
	And test name starts with "Test 1"
	And inputs are
	| Variable Name | Value |
	| a             |       |
	And outputs as
	| Variable Name | Value |
	| outputValue   |       |
	And save is enabled
	When "Workflow 1" is deleted
	When I save
	Then The "Workflow Deleted" popup is shown I click Ok
	And the tab is closed

@TestFramework
Scenario: Run Selected Test fails when workflow deleted
	Given the test builder is open with "Workflow 1"
	And Tab Header is "Workflow 1 - Tests"
	And there are no tests
	And I click New Test
	Then a new test is added
	And Tab Header is "Workflow 1 - Tests *"
	And test name starts with "Test 1"
	And inputs are
	| Variable Name | Value |
	| a             |       |
	And outputs as
	| Variable Name | Value |
	| outputValue   |       |
	And save is enabled
	When I save
	Then Tab Header is "Workflow 1 - Tests"
	And I close the test builder
	When the test builder is open with "Workflow 1"
	Then there are 1 tests
	And "Dummy Test" is selected
	And I select "Test 1"
	And "Test 1" is selected
	And test name starts with "Test 1"
	And inputs are
	| Variable Name | Value |
	| a             |       |
	And outputs as
	| Variable Name | Value |
	| outputValue   |       |
	And save is disabled
	When "Workflow 1" is deleted
	And I run selected test
	Then The "Workflow Deleted" popup is shown I click Ok
	And the tab is closed

@TestFramework
Scenario: Run All Tests fails when workflow deleted
	Given the test builder is open with "Workflow 1"
	And Tab Header is "Workflow 1 - Tests"
	And there are no tests
	And I click New Test
	Then a new test is added
	And Tab Header is "Workflow 1 - Tests *"
	And test name starts with "Test 1"
	And inputs are
	| Variable Name | Value |
	| a             |       |
	And outputs as
	| Variable Name | Value |
	| outputValue   |       |
	And save is enabled
	When I save
	Then Tab Header is "Workflow 1 - Tests"
	And I close the test builder
	When the test builder is open with "Workflow 1"
	Then there are 1 tests
	When "Workflow 1" is deleted
	And I run all tests
	Then The "Workflow Deleted" popup is shown I click Ok
	And the tab is closed

@TestFramework
Scenario: Edit existing test validate star	
	Given the test builder is open with "Workflow 3"
	And Tab Header is "Workflow 3 - Tests"
	And there are no tests
	And I click New Test
	And I set Test Values as
	| TestName | AuthenticationType | Error |
	| Test1    | Windows            | true  |
	When I save
	Then Tab Header is "Workflow 3 - Tests"
	When I click New Test
	And I set Test Values as
	| TestName | AuthenticationType | Error |
	| Test2    | Windows            | true  |
	And save is enabled
	When I save
	Then Tab Header is "Workflow 3 - Tests"
	And I close the test builder
	When the test builder is open with "Workflow 3"
	Then there are 2 tests
	And I select "Test2"
	And I set Test Values as
	| TestName | AuthenticationType | Error |
	| Test2    | Public             | true  |
	Then Name for display is "Test2 *" and test is edited
	And I set Test Values as
	| TestName | AuthenticationType | Error |
	| Test2    | Windows            | true  |
	Then Name for display is "Test2" and test is not edited

@TestFramework
Scenario: Edit existing test  	
	Given the test builder is open with "Workflow 3"
	And Tab Header is "Workflow 3 - Tests"
	And there are no tests
	And I click New Test
	And I set Test Values as
	| TestName | AuthenticationType | Error |
	| Test1    | Windows            | true  |
	Then NoErrorExpected is "false"	
	And save is enabled
	When I save
	Then Tab Header is "Workflow 3 - Tests"
	When I click New Test
	And I set Test Values as
	| TestName | AuthenticationType | Error |
	| Test2    | Windows            | true  |
	And save is enabled
	When I save
	Then Tab Header is "Workflow 3 - Tests"
	And I close the test builder
	When the test builder is open with "Workflow 3"
	Then there are 2 tests
	And I select "Test2"
	Then Duplicate Test is "Enabled"
	And I set Test Values as
	| TestName | AuthenticationType | Error |
	| Test2    | Public            | true  |
	When I save
	Then Tab Header is "Workflow 3 - Tests"
	And I close the test builder
	When the test builder is open with "Workflow 3"
	Then there are 2 tests
	And I select "Test2"
	And Test name is "Test2"
	And Authentication is Public

@TestFramework
Scenario: Rename existing test
	Given the test builder is open with "Workflow 3"
	And Tab Header is "Workflow 3 - Tests"
	And there are no tests
	And I click New Test
	And I set Test Values as
	| TestName | AuthenticationType | Error |
	| Test1    | Windows            | true  |
	Then NoErrorExpected is "false"	
	And save is enabled
	When I save
	Then Tab Header is "Workflow 3 - Tests"
	When I click New Test
	And I set Test Values as
	| TestName | AuthenticationType | Error |
	| Test2    | Windows            | true  |
	And save is enabled
	When I save
	Then Tab Header is "Workflow 3 - Tests"
	And I close the test builder
	When the test builder is open with "Workflow 3"
	Then there are 2 tests
	And I select "Test2"
	When I change the test name to "testing2"
	Then save is enabled
	When I save
	Then test URL is "http://localhost:3142/secure/Examples/Workflow 1.tests/testing2"
	Then Tab Header is "Workflow 3 - Tests"
	And I close the test builder
	When the test builder is open with "Workflow 3"
	Then there are 2 tests
	And I select "testing2"
	And Test name is "testing2"

@TestFramework
Scenario: Loading existing Tests has correct Name for display
	Given the test builder is open with "Workflow 3"
	And Tab Header is "Workflow 3 - Tests"
	And there are no tests
	And I click New Test
	And I set Test Values as
	| TestName | AuthenticationType | Error |
	| Test1    | Windows            | true  |
	When I save
	Then Tab Header is "Workflow 3 - Tests"
	And I close the test builder
	When the test builder is open with "Workflow 3"
	Then there are 1 tests
	And I select "Test1"
	And Name for display is "Test1" and test is not edited

@TestFramework
Scenario: Loading existing Tests has correct Test Status
	Given the test builder is open with "Workflow 3"
	And Tab Header is "Workflow 3 - Tests"
	And there are no tests
	And I click New Test
	And I set Test Values as
	| TestName | AuthenticationType | Error |
	| Test1    | Windows            | true  |
	Then Test Status saved is "TestPending"	
	And save is enabled
	When I save
	Then Tab Header is "Workflow 3 - Tests"
	And I close the test builder
	When the test builder is open with "Workflow 3"
	Then there are 1 tests
	And Test Status is "TestPending"

@TestFramework
Scenario: Loading existing Tests  	
	Given the test builder is open with "Workflow 3"
	And Tab Header is "Workflow 3 - Tests"
	And there are no tests
	And I click New Test
	And I set Test Values as
	| TestName | AuthenticationType | Error |
	| Test1    | Windows            | true  |
	When I save
	Then Tab Header is "Workflow 3 - Tests"
	When I click New Test
	And I set Test Values as
	| TestName | AuthenticationType | Error |
	| Test2    | Windows            | true  |
	And save is enabled
	When I save
	Then Tab Header is "Workflow 3 - Tests"
	And I close the test builder
	When the test builder is open with "Workflow 3"
	Then there are 2 tests

@TestFramework
Scenario: Close test window
	Given the test builder is open with "Workflow 3"
	And Tab Header is "Workflow 3 - Tests"
	And there are no tests
	And I click New Test
	And I set Test Values as
	| TestName | AuthenticationType | Error |
	| Test1    | Windows            | true  |
	When I save
	Then Tab Header is "Workflow 3 - Tests"
	When I click "Test1"
	And I set Test Values as
	| TestName | AuthenticationType | Error |
	| NewName  | Windows            | false |
	Then Tab Header is "Workflow 3 - Tests *"

@TestFramework
Scenario: Delete an Disabled Test
	Given the test builder is open with "Workflow 3"
	And Tab Header is "Workflow 3 - Tests"
	And there are no tests
	And I click New Test
	And I set Test Values as
	| TestName | AuthenticationType | Error |
	| Test1    | Windows            | true  |
	When I save
	Then Tab Header is "Workflow 3 - Tests"
	And there are 1 tests
	When I enable "Test1"
	Then Delete is disabled for "Test1"
	When I disable "Test1"
	Then Delete is enabled for "Test1"
	When I delete "Test1"
	Then The "DeleteConfirmation" popup is shown I click Ok
	Then there are 0 tests

@TestFramework
Scenario: Delete Resource with tests
	Given I have a resouce "PluginSource"
	And I add "test1,test2,test3" as tests
	Then "PluginSource" has 3 tests
	When I delete resource "PluginSource"
	Then "PluginSource" has 0 tests

@TestFramework
Scenario: Delete folder with resources deletes all tests
	Given I have a folder "Home" 
	And I have a resouce workflow "PluginSource1" inside Home
	And I add "test 1,test 2,test 3" to "PluginSource1"
	And I have a resouce workflow "Hello bob" inside Home
	And I add "test 4,test 5,test 6" to "Hello bob"
	Then "PluginSource1" has 3 tests
	And "Hello bob" has 3 tests
	When I delete folder "Home"
	Then "PluginSource1" has 0 tests
	And "Hello bob" has 0 tests

@TestFramework
Scenario: Run all unselects all tests on selection shows corect debug
	Given the test builder is open with "Hello World"
	And I add "test 1,test 2,test 3" to "Hello World"
	Then there are 3 tests	
	When I run all tests
	And selected test is empty
	And I select "test 1"
	Then debug window is visible	


@TestFramework
Scenario: Duplicate a test
	Given the test builder is open with "Workflow 1"
	And Tab Header is "Workflow 1 - Tests"
	And there are no tests
	And I click New Test
	Then a new test is added
	And Tab Header is "Workflow 1 - Tests *"
	And test name starts with "Test 1"
	And inputs are
	| Variable Name | Value |
	| a             |       |
	And outputs as
	| Variable Name | Value |
	| outputValue   |       |
	And save is enabled
	When I save
	Then Tab Header is "Workflow 1 - Tests"
	And there are 1 tests
	When I click "Test 1"
	Then Duplicate Test is visible
	When I click duplicate 
	Then there are 2 tests
	And the duplicated tests is "Test 1 1"
	And save is enabled
	When I save

@TestFramework
Scenario: Duplicate a test with same name fails
	Given the test builder is open with "Workflow 1"
	And Tab Header is "Workflow 1 - Tests"
	And there are no tests
	And I click New Test
	Then a new test is added
	And Tab Header is "Workflow 1 - Tests *"
	And test name starts with "Test 1"
	And inputs are
	| Variable Name | Value |
	| a             |       |
	And outputs as
	| Variable Name | Value |
	| outputValue   |       |
	And save is enabled
	When I save
	Then Tab Header is "Workflow 1 - Tests"
	And there are 1 tests
	When I click "Test 1"
	Then Duplicate Test is visible
	When I click duplicate 
	Then there are 2 tests
	And the duplicated tests is "Test 1 1"
	When I change the test name to "Test 1"
	And save is enabled
	When I save
	Then The duplicate Name popup is shown
	And Duplicate Test is "Disabled"

@TestFramework
Scenario: Run a test with single scalar inputs and outputs
	Given the test builder is open with existing service "Hello World"	
	And Tab Header is "Hello World - Tests"
	When I click New Test
	Then a new test is added
	And Tab Header is "Hello World - Tests *"
	And test name starts with "Test 1"
	And username is blank
	And password is blank
	And inputs are
	| Variable Name | Value |
	| Name          |       |
	And outputs as
	| Variable Name | Value |
	| Message       |       |
	And save is enabled
	And test status is pending
	And test is enabled
	And I update inputs as
	| Variable Name | Value |
	| Name          | Bob   |
	And I update outputs as
	| Variable Name | Value      |
	| Message       | Hello Bob. |
	And I save
	When I run the test
	Then test result is Passed
	And service debug inputs as
		| Variable | Value |
		| [[Name]] | Bob   |
	And the service debug outputs as
	  | Variable    | Value      |
	  | [[Message]] | Hello Bob. |
	When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok
	And test folder is cleaned

@TestFramework
Scenario: Run a test with single scalar inputs and outputs failure
	Given the test builder is open with existing service "Hello World"	
	And Tab Header is "Hello World - Tests"
	When I click New Test
	Then a new test is added
	And Tab Header is "Hello World - Tests *"
	And test name starts with "Test 1"
	And username is blank
	And password is blank
	And inputs are
	| Variable Name | Value |
	| Name          |       |
	And outputs as
	| Variable Name | Value |
	| Message       |       |
	And save is enabled
	And test status is pending
	And test is enabled
	And I update inputs as
	| Variable Name | Value |
	| Name          | Bob   |
	And I update outputs as
	| Variable Name | Value      |
	| Message       | Hello Mary. |
	And I save
	When I run the test
	Then test result is Failed
	Then service debug inputs as
		| Variable | Value |
		| [[Name]] | Bob   |	
	And the service debug outputs as
	  | Variable    | Value      |
	  | [[Message]] | Hello Bob. |
		When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok
	And test folder is cleaned

#Feedback specs
@TestFramework
Scenario: Duplicate test new test has name
	Given the test builder is open with "Workflow 1"
	And Tab Header is "Workflow 1 - Tests"
	And there are no tests
	And I click New Test
	Then a new test is added
	And Tab Header is "Workflow 1 - Tests *"
	And test name starts with "Test 1"
	And inputs are
	| Variable Name | Value |
	| a             |       |
	And outputs as
	| Variable Name | Value |
	| outputValue   |       |
	And save is enabled
	When I save
	Then Tab Header is "Workflow 1 - Tests"
	And there are 1 tests
	When I click "Test 1"
	Then Duplicate Test is visible
	When I click duplicate 
	Then there are 2 tests
	And Test name is "Test 1 1"

@TestFramework
Scenario: Run Selected Test Shows Stop Option
	Given the test builder is open with "Workflow 1"
	And Tab Header is "Workflow 1 - Tests"
	And there are no tests
	And I click New Test
	Then a new test is added
	And Tab Header is "Workflow 1 - Tests *"
	And test name starts with "Test 1"
	And inputs are
	| Variable Name | Value |
	| a             |       |
	And outputs as
	| Variable Name | Value |
	| outputValue   |       |
	And save is enabled
	When I save
	Then Tab Header is "Workflow 1 - Tests"
	And I close the test builder
	When the test builder is open with "Workflow 1"
	Then there are 1 tests
	And "Dummy Test" is selected
	And I select "Test 1"
	And "Test 1" is selected
	And test name starts with "Test 1"
	And inputs are
	| Variable Name | Value |
	| a             |       |
	And outputs as
	| Variable Name | Value |
	| outputValue   |       |
	And save is disabled
	When I run selected test

@TestFramework
Scenario: Run a test with mock step
	Given the test builder is open with existing service "Hello World"	
	And Tab Header is "Hello World - Tests"
	When I click New Test
	Then a new test is added
	And Tab Header is "Hello World - Tests *"
	And test name starts with "Test 1"	
	And test is enabled
	And I update inputs as
	| Variable Name | Value |
	| Name          | Bob   |
	And I update outputs as
	| Variable Name | Value       |
	| Message       | Hello World. |
	And I add mock steps as
	| Step Name                  | Output Variable | Output Value | Activity Type |
	| If [[Name]] <> (Not Equal) | Flow Arm        | Blank Input  | Decision      |
	And I save
	When I run the test
	Then test result is Passed
	Then service debug inputs as
		| Variable | Value |
		| [[Name]] | Bob   |	
	And the service debug outputs as
	  | Variable    | Value      |
	  | [[Message]] | Hello World. |
	When I delete "Test 1"	
	Then The "DeleteConfirmation" popup is shown I click Ok
	#And test folder is cleaned
@s3
@TestFramework
Scenario: Run a test with mock step assign
	Given the test builder is open with existing service "Hello World"	
	And Tab Header is "Hello World - Tests"
	When I click New Test
	Then a new test is added
	And Tab Header is "Hello World - Tests *"
	And test name starts with "Test 1"	
	And test is enabled
	And I update inputs as
	| Variable Name | Value |
	| Name          | Bob   |
	And I update outputs as
	| Variable Name | Value      |
	| Message       | hello mock |
	And I add mock steps as
	| Step Name                   | Output Variable | Output Value | Activity Type | Output From | Output To |
	| Set the output variable (1) | Message         | hello mock   | Assign        |             |           |
	And I save
	When I run the test
	Then test result is Passed
	Then service debug inputs as
		| Variable | Value |
		| [[Name]] | Bob   |	
	And the service debug outputs as
	  | Variable    | Value      |
	  | [[Message]] | hello mock |
	When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok	
	#And test folder is cleaned
@s4
Scenario: Run a test with Assert step assign
	Given the test builder is open with existing service "Hello World"	
	And Tab Header is "Hello World - Tests"
	When I click New Test
	Then a new test is added
	And Tab Header is "Hello World - Tests *"
	And test name starts with "Test 1"	
	And test is enabled
	And I update inputs as
	| Variable Name | Value |
	| Name          | Bob   |
	And I update outputs as
	| Variable Name | Value      |
	| Message       | hello mock |
	And I add Assert steps as
	| Step Name                   | Output Variable | Output Value | Activity Type | Output From | Output To |
	| Set the output variable (1) | Message         | hello mock   | Assign        |             |           |
	And I save
	When I run the test
	Then test result is Failed
	Then service debug inputs as
		| Variable | Value |
		| [[Name]] | Bob   |	
	And the service debug outputs as
	  | Variable    | Value      |
	  | [[Message]] | Hello Bob. |
	When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok	
	#And test folder is cleaned
@s5
	Scenario: Run a test with Assert step
	Given the test builder is open with existing service "Hello World"	
	And Tab Header is "Hello World - Tests"
	When I click New Test
	Then a new test is added
	And Tab Header is "Hello World - Tests *"
	And test name starts with "Test 1"	
	And test is enabled
	And I update inputs as
	| Variable Name | Value |
	| Name          |       |
	And I update outputs as
	| Variable Name | Value       |
	| Message       | Hello World. |
	And I add Assert steps as
	| Step Name                  | Output Variable | Output Value | Activity Type | Output From | Output To |
	| If [[Name]] <> (Not Equal) | Message         | Blank Input  | Decision      |             |           |
	And I save
	When I run the test
	Then test result is Passed
	Then service debug inputs as
		| Variable | Value |
		| [[Name]] |       |
	And the service debug outputs as
	  | Variable    | Value      |
	  | [[Message]] | Hello World. |
	When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok
	#And test folder is cleaned
	

Scenario: Run a test with Error Expected
	Given the test builder is open with existing service "Error WF"	
	And Tab Header is "Error WF - Tests"
	When I click New Test
	Then a new test is added
	And Tab Header is "Error WF - Tests *"
	And test name starts with "Test 1"	
	And test is enabled
	Then I set ErrorExpected to "true"	
	And change ErrorContainsText to "Recordset is null [[rec()]]"
	When I run the test
	Then test result is Passed
	When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok
	

#Web Execution
Scenario: Run Selected Test in Web
	Given the test builder is open with "Hello World"
	And Tab Header is "Hello World - Tests"
	And there are no tests
	And I click New Test
	Then a new test is added
	And Tab Header is "Hello World - Tests *"
	And test name starts with "Test 1"
	And inputs are
	| Variable Name | Value |
	| Name             |       |
	And outputs as
	| Variable Name | Value |
	| Message   |       |
	And save is enabled
	When I save
	Then Tab Header is "Hello World - Tests"
	And I close the test builder
	When the test builder is open with "Hello World"
	Then there are 1 tests
	And "Dummy Test" is selected
	And I select "Test 1"
	And "Test 1" is selected
	And test name starts with "Test 1"
	And inputs are
	| Variable Name | Value |
	| Name             |       |
	And outputs as
	| Variable Name | Value |
	| Message   |       |
	And save is disabled
	When I run selected test in Web
	Then The WebResponse as
	| Test Name | Result | Message |
	| Test 1    | Failed |         |

Scenario: Run All Tests in Web 
	Given the test builder is open with "Hello World"
	And Tab Header is "Hello World - Tests"
	And there are no tests
	And I click New Test
	Then a new test is added
	And Tab Header is "Hello World - Tests *"
	And test name starts with "Test 1"
	And I update inputs as
	| Variable Name | Value |
	| Name          |       |
	And I update outputs as
	| Variable Name | Value       |
	| Message       | Hello World. |
	And save is enabled
	When I save
	Then Tab Header is "Hello World - Tests"
	And I close the test builder
	When the test builder is open with "Hello World"
	Then there are 1 tests
	When I run all tests in Web
	Then The WebResponse as
	| Test Name | Result | Message |
	| Test 1    | Passed |         |

Scenario: Run Selected Test passed with all teststeps fails
	Given the test builder is open with "Hello World"
	And Tab Header is "Hello World - Tests"
	And there are no tests
	And I click New Test
	Then a new test is added
	And Tab Header is "Hello World - Tests *"
	And test name starts with "Test 1"
	And inputs are
	| Variable Name | Value |
	| Name             |       |
	And outputs as
	| Variable Name | Value |
	| Message   |       |
	And I Add all TestSteps
	And save is enabled
	When I save
	And I run the test
	Then test result is Failed
	
Scenario: Run Selected Test passed with assign teststep Passes
	Given the test builder is open with "Hello World"
	And Tab Header is "Hello World - Tests"
	And there are no tests
	And I click New Test
	Then a new test is added
	And Tab Header is "Hello World - Tests *"
	And test name starts with "Test 1"
	And inputs are
	| Variable Name | Value |
	| Name             |       |
	And outputs as
	| Variable Name | Value |
	| Message   |       |
	And I Add "Assign a value to Name if blank (1)" as TestStep
	And save is enabled
	When I save
	And I run the test
	Then test result is Failed
	
Scenario: Control Flow - Sequence Debug Run Selected Test passed with create Example Data teststep Passes
	Given the test builder is open with "Control Flow - Sequence"
	And Tab Header is "Control Flow - Sequence - Tests"
	Then there are 3 tests		
	And I select "ControlFlowExampleWithExampleDataStepTests"
	And test name starts with "ControlFlowExampleWithExampleDataStepTests"	
	When I run the test	
	Then test result is Passed
	And I select "ControlFlowExampleWithForEachStepTest"
	And test name starts with "ControlFlowExampleWithForEachStepTest"	
	When I run the test	
	Then test result is Passed
	And I select "ControlFlowExampleWithOrganiseCustomerStepTest"
	And test name starts with "ControlFlowExampleWithOrganiseCustomerStepTest"	
	When I run the test	
	Then test result is Passed	
	And I run all tests
	Then all tests pass

Scenario: Loop Constructs - For Each Debug Run Selected Test passed with create Example Data teststep Passes
	Given the test builder is open with "Loop Constructs - For Each"
	And Tab Header is "Loop Constructs - For Each - Tests"
	Then there are 0 tests	
	And I click New Test
	Then a new test is added	
    And test name starts with "Test 1"
	And I Add all "For each" as TestStep
	And I add StepOutputs as 
	| Variable Name  | Condition  | Value | stepIndex | ChildIndex |
	| [[rec(6).set]] | <>         |       | 0         | 0          |
	| [[rec(3).set]] | Not Email  |       | 1         | 0          |
	| [[rec(7).set]] | Is Numeric |       | 2         | 0          |
	And save is enabled
	When I save
	And I run the test
	Then test result is Passed

Scenario: Loop Constructs - Select and Apply Debug Run Selected Test passed with create Example Data teststep Passes
	Given the test builder is open with "Loop Constructs - Select and Apply"
	And Tab Header is "Loop Constructs - Select and Apply - Tests"
	Then there are 0 tests	
	And I click New Test
	Then a new test is added	
	And Tab Header is "Loop Constructs - Select and Apply - Tests *"
    And test name starts with "Test 1"
	And I Add all "Select and apply" as TestStep
	And I add StepOutputs as 
	| Variable Name           | Condition | Value   | stepIndex | ChildIndex |
	| [[PetsName]]            | =         | The Guv | 0         | 0          |
	| [[@Pet.Name]]           | =         | The Guv | 0         | 1          |
	| [[_pfname]]             | =         | DAISY   | 1         | 0          |
	| [[@Pet.Friend(1).Name]] | =         | DAISY   | 1         | 1          |
	| [[@Pet.Friend(2).Name]] | =         | ALEX    | 1         | 1          |
	| [[@Pet.Friend(3).Name]] | =         | JAMIE   | 1         | 1          |	
	And save is enabled
	When I save
	And I run the test
	Then test result is Passed

#Data Category
Scenario: Test WF with Assign
	Given I have a workflow "AssignTestWF"
	And "AssignTestWF" contains an Assign "TestAssign" as
	  | variable    | value |
	  | [[rec().a]] | yes   |
	  | [[rec().a]] | no    |
	And I save workflow "AssignTestWF"
	Then the test builder is open with "AssignTestWF"
	And I click New Test
	And a new test is added	
    And test name starts with "Test 1"
	And I Add "TestAssign" as TestStep
	And I add new StepOutputs as 
	| Variable Name | Condition | Value | 
	| [[rec(1).a]]  | =         | yes   | 
	| [[rec(2).a]]  | =         | no    | 
	When I save
	And I run the test
	Then test result is Passed
	When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok
	Then workflow "AssignTestWF" is deleted as cleanup

Scenario: Test WF with Assign Object
		Given I have a workflow "AssignObjectTestWF"
		And "AssignObjectTestWF" contains an Assign Object "TestAssignObject" as 
		 | variable            | value |
		 | [[@Person.Name]]    | yes   |
		 | [[@Person.Surname]] | no    |
		 And I save workflow "AssignObjectTestWF"
		 Then the test builder is open with "AssignObjectTestWF"
		 And I click New Test
		 And a new test is added	
	   	 And test name starts with "Test 1"
		 And I Add "TestAssignObject" as TestStep
		 And I add new StepOutputs as 
		 | Variable Name       | Condition | Value | 
		 | [[@Person.Name]]    | =         | yes   | 
		 | [[@Person.Surname]] | =         | no    | 
		 When I save
		 And I run the test
		 Then test result is Passed
		 When I delete "Test 1"
		 Then The "DeleteConfirmation" popup is shown I click Ok
		 Then workflow "AssignObjectTestWF" is deleted as cleanup

Scenario: Test WF with BaseConvert 
		Given I have a workflow "BaseConvertTestWF"
		And "BaseConvertTestWF" contains an Assign "TestAssign" as
		  | variable | value                                                                                                    |
		  | [[a]]    | 01001001001000000111011101100001011100110010000001101101011000010110111001100111011011000110010101100100 |
		And "BaseConvertTestWF" contains Base convert "TestBaseConvert" as
		  | Variable  | From   | To   |
		  | [[a]] | Binary | Text |
		 And I save workflow "BaseConvertTestWF"
		 Then the test builder is open with "BaseConvertTestWF"
		 And I click New Test
		 And a new test is added	
		 And test name starts with "Test 1"
		 And I Add "TestBaseConvert" as TestStep
		 And I add new StepOutputs as 
		  | Variable Name | Condition | Value         |
		  | [[a]]         | =         | I was mangled |
		 When I save
		 And I run the test
		 Then test result is Passed
		 When I delete "Test 1"
		 Then The "DeleteConfirmation" popup is shown I click Ok
		 Then workflow "BaseConvertTestWF" is deleted as cleanup
		
Scenario: Test WF with CaseConvert
		Given I have a workflow "CaseConvertTestWF"
			And "CaseConvertTestWF" contains an Assign "TestAssign" as
		 | variable    | value |
		 | [[rec().a]] | 50    |
		 | [[rec().a]] | test  |
		 | [[rec().a]] | 100   |
		And "CaseConvertTestWF" contains case convert "TestCaseConvert" as
		  | Variable     | Type  |
		  | [[rec(2).a]] | UPPER |
		 And I save workflow "CaseConvertTestWF"
		 Then the test builder is open with "CaseConvertTestWF"
		 And I click New Test
		 And a new test is added	
		 And test name starts with "Test 1"
		 And I Add "TestCaseConvert" as TestStep
		 And I add new StepOutputs as 
		 | Variable Name | Condition | Value |
		 | [[rec(2).a]]  | =         | TEST  |
		 When I save
		 And I run the test
		 Then test result is Passed
		 When I delete "Test 1"
		 Then The "DeleteConfirmation" popup is shown I click Ok
		 Then workflow "CaseConvertTestWF" is deleted as cleanup
	
Scenario: Test WF with Data split
		Given I have a workflow "DataSplitTestWF"
		And "DataSplitTestWF" contains an Assign "TestAssign" as
		 | variable        | value                                                                              |
		 | [[FileContent]] | Brad,5546854,brad@mail.com Bob,65548912,bob@mail.com Bill,3215464987,bill@mail.com |
		And "DataSplitTestWF" contains Data Split "TestDataSplit" as	
		| String          | Variable       | Type  | At | Include | Escape |
		| [[FileContent]] | [[rec().Name]] | Chars | ,  |         |        |
		 And I save workflow "DataSplitTestWF"
		 Then the test builder is open with "DataSplitTestWF"
		 And I click New Test
		 And a new test is added	
		 And test name starts with "Test 1"
		 And I Add "TestDataSplit" as TestStep
		 And I add new StepOutputs as 
	  	 | Variable Name   | Condition | Value             |
	  	 | [[rec(1).Name]] | =         | Brad              |
	  	 | [[rec(2).Name]] | =         | 5546854           |
	  	 | [[rec(3).Name]] | =         | brad@mail.com Bob |
	  	 | [[rec(4).Name]] | =         | 65548912          |
	  	 | [[rec(5).Name]] | =         | bob@mail.com Bill |
	  	 | [[rec(6).Name]] | =         | 3215464987        |
	  	 | [[rec(7).Name]] | =         | bill@mail.com     |
		 When  I save
		 And I run the test
		 Then test result is Passed
		 When I delete "Test 1"
		 Then The "DeleteConfirmation" popup is shown I click Ok
		 Then workflow "DataSplitTestWF" is deleted as cleanup
		
Scenario: Test WF with Find Index
		Given I have a workflow "FindIndexTestWF"
		And "FindIndexTestWF" contains an Assign "TestAssign" as
		   | variable    | value    |
			  | [[rec().a]] | test     |
			  | [[rec().b]] | nothing  |
			  | [[rec().a]] | warewolf |
			  | [[rec().b]] | nothing  |
		And "FindIndexTestWF" contains Find Index "TestIndex" into "[[indexResult]]" as
		  | In Fields   | Index           | Character | Direction     |
		  | [[rec().a]] | First Occurence | e         | Left to Right |
		 And I save workflow "FindIndexTestWF"
		 Then the test builder is open with "FindIndexTestWF"
		 And I click New Test
		 And a new test is added	
		 And test name starts with "Test 1"
		 And I Add "TestIndex" as TestStep
		 And I add new StepOutputs as 
		 | Variable Name   | Condition | Value |
		 | [[indexResult]] | =         | 4     |
		 When I save
		 And I run the test
		 Then test result is Passed
		 When I delete "Test 1"
	 	 Then The "DeleteConfirmation" popup is shown I click Ok
		 Then workflow "FindIndexTestWF" is deleted as cleanup


Scenario: Test WF with Data Merge
		Given I have a workflow "DataMergeTestWF"
		And "DataMergeTestWF" contains an Assign "TestAssign" as
		  | variable      | value    |
		  | [[a]]         | Test     |
		  | [[b]]         | Warewolf |
		  | [[split().a]] | Workflow |
		And "DataMergeTestWF" contains Data Merge "TestDataMerge" into "[[result]]" as			
		  | Variable | Type  | Using | Padding | Alignment |
		  | [[a]]    | Index | 4     |         | Left      |
		  | [[b]]    | Index | 8     |         | Left      |
		And I save workflow "DataMergeTestWF"
		Then the test builder is open with "DataMergeTestWF"
		And I click New Test
		And a new test is added	
		And test name starts with "Test 1"
		And I Add "TestDataMerge" as TestStep
		And I add new StepOutputs as 
		| Variable Name | Condition | Value        |
		| [[result]]    | =         | TestWarewolf |
		When I save
		And I run the test
		Then test result is Passed
		When I delete "Test 1"
		Then The "DeleteConfirmation" popup is shown I click Ok
		Then workflow "DataMergeTestWF" is deleted as cleanup
		
Scenario: Test WF with Replace
		Given I have a workflow "ReplaceTestWF"
		And "ReplaceTestWF" contains an Assign "TestAssign" as
		 | variable    | value    |
		  | [[rec().a]] | test     |
		  | [[rec().b]] | nothing  |
		  | [[rec().a]] | warewolf |
		  | [[rec().b]] | nothing  |
	  And "ReplaceTestWF" contains Replace "TestReplace" into "[[replaceResult]]" as	
		  | In Fields  | Find | Replace With |
		  | [[rec(*)]] | e    | REPLACED     |
		And I save workflow "ReplaceTestWF"
		Then the test builder is open with "ReplaceTestWF"
		And I click New Test
		And a new test is added	
		And test name starts with "Test 1"
		And I Add "TestReplace" as TestStep
		And I add new StepOutputs as 
		| Variable Name     | Condition | Value           |
		| [[rec(1).a]]      | =         | tREPLACEDst     |
		| [[rec(2).a]]      | =         | warREPLACEDwolf |		
		| [[replaceResult]] | =         | 2               |
		When I save
		And I run the test
		Then test result is Passed
		When I delete "Test 1"
		Then The "DeleteConfirmation" popup is shown I click Ok
		Then workflow "ReplaceTestWF" is deleted as cleanup

#Database Category	  
Scenario: Test WF with MySql
		Given I have a workflow "MySqlTestWF"
		 And "MySqlTestWF" contains a mysql database service "MySqlEmail" with mappings as
		  | Input to Service | From Variable | Output from Service | To Variable      |
		  |                  |               | name                | [[rec(*).name]]  |
		  |                  |               | email               | [[rec(*).email]] |	
		And I save workflow "MySqlTestWF"
		Then the test builder is open with "MySqlTestWF"
		And I click New Test
		And a new test is added	
		And test name starts with "Test 1"
		And I Add "MySqlEmail" as TestStep
		And I add new StepOutputs as 
		| Variable Name           | Condition | Value              |
		| [[MySqlEmail(1).name]]  | =         | Monk               |
		| [[MySqlEmail(1).email]] | =         | dora@explorers.com |		
		When I save
		And I run the test
		Then test result is Passed
		When I delete "Test 1"
		Then The "DeleteConfirmation" popup is shown I click Ok
		Then workflow "MySqlTestWF" is deleted as cleanup

Scenario: Test WF with Sql Server
		Given I have a workflow "SqlTestWF"
		 And "SqlTestWF" contains a sqlserver database service "dbo.Pr_CitiesGetCountries" with mappings as
		  | Input to Service | From Variable | Output from Service | To Variable      |
		  | Prefix           | afg           | countryid           | [[rec(*).name]]  |
		  |                  |               | description         | [[rec(*).email]] |
		And I save workflow "SqlTestWF"
		Then the test builder is open with "SqlTestWF"
		And I click New Test
		And a new test is added	
		And test name starts with "Test 1"
		And I Add "dbo.Pr_CitiesGetCountries" as TestStep
		And I add new StepOutputs as 
		| Variable Name                | Condition | Value       |
		| [[countries(1).id]]          | =         | 1           |
		| [[countries(1).description]] | =         | Afghanistan |		
		When I save
		And I run the test
		Then test result is Passed
		When I delete "Test 1"
		Then The "DeleteConfirmation" popup is shown I click Ok
		Then workflow "SqlTestWF" is deleted as cleanup

Scenario: Test WF with Oracle
		Given I have a workflow "MySqlTestWF"
		 And "MySqlTestWF" contains a mysql database service "MySqlEmail" with mappings as
		  | Input to Service | From Variable | Output from Service | To Variable      |
		  |                  |               | name                | [[rec(*).name]]  |
		  |                  |               | email               | [[rec(*).email]] |	
		And I save workflow "MySqlTestWF"
		Then the test builder is open with "MySqlTestWF"
		And I click New Test
		And a new test is added	
		And test name starts with "Test 1"
		And I Add "MySqlEmail" as TestStep
		And I add new StepOutputs as 
		| Variable Name           | Condition | Value              |
		| [[MySqlEmail(1).name]]  | =         | Monk               |
		| [[MySqlEmail(1).email]] | =         | dora@explorers.com |		
		When I save
		And I run the test
		Then test result is Passed
		When I delete "Test 1"
		Then The "DeleteConfirmation" popup is shown I click Ok
		Then workflow "MySqlTestWF" is deleted as cleanup

Scenario: Test WF with PostGre Sql
		Given I have a workflow "PostGreTestWF"
		 And "PostGreTestWF" contains a postgre tool using "get_countries" with mappings as
		  | Input to Service | From Variable | Output from Service | To Variable           |
		  | Prefix           | s             | name                | [[countries(*).Id]]   |
		  |                  |               | email               | [[countries(*).Name]] |
		And I save workflow "PostGreTestWF"
		Then the test builder is open with "PostGreTestWF"
		And I click New Test
		And a new test is added	
		And test name starts with "Test 1"
		And I Add "get_countries" as TestStep
		And I add new StepOutputs as 
		| Variable Name         | Condition | Value         |
		| [[countries(1).Id]]   | =         | 1             |
		| [[countries(2).Id]]   | =         | 3             |
		| [[countries(1).Name]] | =         | United States |
		| [[countries(2).Name]] | =         | South Africa  |	
		When I save
		And I run the test
		Then test result is Passed
		When I delete "Test 1"
		Then The "DeleteConfirmation" popup is shown I click Ok
		Then workflow "PostGreTestWF" is deleted as cleanup
Scenario: Test WF with Decision
		Given I have a workflow "DecisionTestWF"
		And "DecisionTestWF" contains an Assign "TestAssign" as
		| variable | value |
		| [[A]]    | 30    |
		And a decision variable "[[A]]" value "30"	
		And decide if "[[A]]" "IsAlphanumeric" 
		And I save workflow "DecisionTestWF"
		Then the test builder is open with "DecisionTestWF" new workflows
		And I click New Test
		And a new test is added	
		And test name starts with "Test 1"
		And I Add "TestDecision" as TestStep
		And I add Assert steps as
		| Step Name                  | Output Variable | Output Value | Activity Type |
		| If [[Name]] <> (Not Equal) | Flow Arm        | True         | Decision      |
		When I save
		And I run the test
		Then test result is Passed
		When I delete "Test 1"
		Then The "DeleteConfirmation" popup is shown I click Ok
		Then workflow "DecisionTestWF" is deleted as cleanup

Scenario: Test WF with SqlBulk Insert
		Given I have a workflow "SqlBulkTestWF"
		 And "SqlBulkTestWF" contains an SQL Bulk Insert "BulkInsert" using database "testingDBSrc" and table "dbo.MailingList" and KeepIdentity set "false" and Result set "[[result]]" as
		   | Column | Mapping             | IsNullable | DataTypeName | MaxLength | IsAutoIncrement |
		   | Id     |                     | false      | int          |           | true            |
		   | Name   | [[rec().a]]         | false      | varchar      | 50        | false           |
		   | Email  | Warewolf@dev2.co.za | false      | varchar      | 50        | false           |
		And I save workflow "SqlBulkTestWF"
		Then the test builder is open with "SqlBulkTestWF"
		And I click New Test
		And a new test is added	
		And test name starts with "Test 1"
		And I Add "BulkInsert" as TestStep
		And I add new StepOutputs as 
		| Variable Name | Condition | Value   |
		| [[result]]    | =         | Success |
		When I save
		And I run the test
		Then test result is Passed
		When I delete "Test 1"
		Then The "DeleteConfirmation" popup is shown I click Ok
		Then workflow "SqlBulkTestWF" is deleted as cleanup

Scenario: Test WF with Odbc
		Given I have a workflow "MySqlTestWF"
		 And "MySqlTestWF" contains a mysql database service "MySqlEmail" with mappings as
		  | Input to Service | From Variable | Output from Service | To Variable      |
		  |                  |               | name                | [[rec(*).name]]  |
		  |                  |               | email               | [[rec(*).email]] |	
		And I save workflow "MySqlTestWF"
		Then the test builder is open with "MySqlTestWF"
		And I click New Test
		And a new test is added	
		And test name starts with "Test 1"
		And I Add "MySqlEmail" as TestStep
		And I add new StepOutputs as 
		| Variable Name           | Condition | Value              |
		| [[MySqlEmail(1).name]]  | =         | Monk               |
		| [[MySqlEmail(1).email]] | =         | dora@explorers.com |		
		When I save
		And I run the test
		Then test result is Passed
		When I delete "Test 1"
		Then The "DeleteConfirmation" popup is shown I click Ok
		Then workflow "MySqlTestWF" is deleted as cleanup

#File ops
Scenario: Test WF with Create
		Given I have a workflow "CreateTestWF"
		And "CreateTestWF" contains an Assign "Assign to create" as
		  | variable    | value           |
		  | [[rec().a]] | C:\copied00.txt |
		And "CreateTestWF" contains an Create "Create1" as
			 | File or Folder | If it exits | Username | Password | Result   |
			 | [[rec().a]]    | True        |          |          | [[res1]] |
		And I save workflow "CreateTestWF"
		Then the test builder is open with "CreateTestWF"
		And I click New Test
		And a new test is added	
		And test name starts with "Test 1"
		And I Add "Create1" as TestStep
		And I add new StepOutputs as 
		| Variable Name | Condition | Value   |
		| [[res1]]      | =         | Success |
		When I save
		And I run the test
		Then test result is Passed
		When I delete "Test 1"
		Then The "DeleteConfirmation" popup is shown I click Ok
		Then workflow "CreateTestWF" is deleted as cleanup

Scenario: Test WF with Create and Delete folder
		Given I have a workflow "DeleteFolderTestWF"
		And "DeleteFolderTestWF" contains an Assign "Assign to create" as
		  | variable    | value           |
		  | [[rec().a]] | C:\copied00.txt |
		And "DeleteFolderTestWF" contains an Create "Create1" as
		  | File or Folder | If it exits | Username | Password | Result   |
		  | [[rec().a]]    | True        |          |          | [[res1]] |
	    And "DeleteFolderTestWF" contains an Delete Folder "DeleteFolder" as
	      | Recordset   | Result   |
	      | [[rec().a]] | [[res2]] |
		And I save workflow "DeleteFolderTestWF"
		Then the test builder is open with "DeleteFolderTestWF"
		And I click New Test
		And a new test is added	
		And test name starts with "Test 1"
		And I Add "DeleteFolder" as TestStep
		And I add new StepOutputs as 
		| Variable Name | Condition | Value   |
		| [[res2]]      | =         | Success |
		When I save
		And I run the test
		Then test result is Passed
		When I delete "Test 1"
		Then The "DeleteConfirmation" popup is shown I click Ok
		Then workflow "DeleteFolderTestWF" is deleted as cleanup

Scenario: Test WF with Move
		Given I have a workflow "MoveTestWF"
		And "MoveTestWF" contains an Assign "Assign to Move" as
		  | variable    | value           |
		  | [[rec().a]] | C:\copied00.txt |
		  | [[rec().b]] | C:\copied01.txt |
		And "MoveTestWF" contains an Move "Move1" as
		  | File or Folder | If it exits | Destination | Username | Password | Result   |
		  | [[rec().a]]    | True        | [[rec().b]] |          |          | [[res1]] |	  
		And I save workflow "MoveTestWF"
		Then the test builder is open with "MoveTestWF"
		And I click New Test
		And a new test is added	
		And test name starts with "Test 1"
		And I Add "Move1" as TestStep
		And I add new StepOutputs as 
		| Variable Name | Condition | Value   |
		| [[res1]]      | =         | Success |
		When I save
		And I run the test
		Then test result is Passed
		When I delete "Test 1"
		Then The "DeleteConfirmation" popup is shown I click Ok
		Then workflow "MoveTestWF" is deleted as cleanup
		
Scenario: Test WF with Read Folder
		Given I have a workflow "ReadFolderTestWF"		
		And "ReadFolderTestWF" contains an Read Folder "ReadFolder" as
		  | File or Folder          | If it exits | Username | Password | Result          | Folders |
		  | C:\ProgramData\Warewolf | True        |          |          | [[rec(*).Name]] | True    |
		And I save workflow "ReadFolderTestWF"
		Then the test builder is open with "ReadFolderTestWF"
		And I click New Test
		And a new test is added	
		And test name starts with "Test 1"
		And I Add "ReadFolder" as TestStep
		And I add new StepOutputs as 
		| Variable Name   | Condition | Value                              |
		| [[rec(7).Name]] | =         | C:\ProgramData\Warewolf\Workspaces |
		When I save
		And I run the test
		Then test result is Passed
		When I delete "Test 1"
		Then The "DeleteConfirmation" popup is shown I click Ok
		Then workflow "ReadFolderTestWF" is deleted as cleanup

Scenario: Test WF with Read File
		Given I have a workflow "ReadFileTestWF"
		And "ReadFileTestWF" contains an Read File "ReadFile" as
		  | File or Folder                            |Username | Password | Result     |
		  | C:\ProgramData\Warewolf\Resources\Log.txt |         |          | [[Result]] |
		And I save workflow "ReadFileTestWF"
		Then the test builder is open with "ReadFileTestWF"
		And I click New Test
		And a new test is added	
		And test name starts with "Test 1"
		And I Add "ReadFile" as TestStep
		And I add new StepOutputs as 
		| Variable Name | Condition | Value |
		| [[Result]]    | Contains  | Hello |
		When I save
		And I run the test
		Then test result is Passed
		When I delete "Test 1"
		Then The "DeleteConfirmation" popup is shown I click Ok
		Then workflow "ReadFileTestWF" is deleted as cleanup

Scenario: Test WF with Rename File
		Given I have a workflow "RenameFileTestWF"		
		And "RenameFileTestWF" contains an Create "Create1" as
		  | File or Folder                                     | If it exits | Username | Password | Result   |
		  | C:\ProgramData\Warewolf\Resources\FileToRename.txt | True        |          |          | [[res1]] |
		And "RenameFileTestWF" contains an Rename "RenameFile" as
		  | File or Folder                                     | Destination                                   | If it exits | Username | Password | Result     | Folders |
		  | C:\ProgramData\Warewolf\Resources\FileToRename.txt | C:\ProgramData\Warewolf\Resources\Renamed.txt | True        |          |          | [[result]] | True    |
		And I save workflow "RenameFileTestWF"
		Then the test builder is open with "RenameFileTestWF"
		And I click New Test
		And a new test is added	
		And test name starts with "Test 1"
		And I Add "RenameFile" as TestStep
		And I add new StepOutputs as 
		| Variable Name | Condition | Value   |
		| [[result]]    | =         | Success |
		When I save
		And I run the test
		Then test result is Passed
		When I delete "Test 1"
		Then The "DeleteConfirmation" popup is shown I click Ok
		Then workflow "RenameFileTestWF" is deleted as cleanup

	  
#Utility
Scenario: Test WF with Random
	Given I have a workflow "RandomTestWF"
	And "RandomTestWF" contains Random "TestRandoms" as
	  | Type    | From | To | Result     |
	  | Numbers | 1    | 10 | [[result]] |
	And I save workflow "RandomTestWF"
	Then the test builder is open with "RandomTestWF"
	And I click New Test
	And a new test is added	
    And test name starts with "Test 1"
	And I Add "TestRandoms" as TestStep	
	And I add new StepOutputs as 
	  	 | Variable Name | Condition  | Value |
	  	 | [[result]]    | Is Numeric |       |
	When I save
	And I run the test
	Then test result is Passed
	When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok
	Then workflow "RandomTestWF" is deleted as cleanup

Scenario: Test WF with Aggregate Calculate
	Given I have a workflow "AggrCalculateTestWF"
	And "AggrCalculateTestWF" contains an Assign "values1" as
      | variable | value |
      | [[a]]    | 31     |
      | [[b]]    | 15     |
      | [[c]]    | 8     |
      | [[d]]    | 24     |
	And "AggrCalculateTestWF" contains Calculate "TestAgrCalculate" with formula "Min([[a]],[[b]],[[c]],[[d]])" into "[[result]]"
	And I save workflow "AggrCalculateTestWF"
	Then the test builder is open with "AggrCalculateTestWF"
	And I click New Test
	And a new test is added	
    And test name starts with "Test 1"
	And I Add "TestAgrCalculate" as TestStep
	And I add new StepOutputs as 
	  	 | Variable Name | Condition | Value |
	  	 | [[result]]    | =         | 8     |
	When I save
	And I run the test
	Then test result is Passed
	When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok
	Then workflow "AggrCalculateTestWF" is deleted as cleanup

Scenario: Test WF with WebRequest
	Given I have a workflow "WebRequestTestWF"
	And "WebRequestTestWF" contains WebRequest "TestWebRequest" as
	| Result       | Url                                                        |
	| "[[Result]]" | http://rsaklfsvrtfsbld/IntegrationTestSite/Proxy.ashx?html |
	And I save workflow "WebRequestTestWF"
	Then the test builder is open with "WebRequestTestWF"
	And I click New Test
	And a new test is added	
    And test name starts with "Test 1"
	And I Add "TestWebRequest" as TestStep
	And I add new StepOutputs as 
	  	 | Variable Name | Condition | Value           |
	  	 | [[Result]]    | Contains  | <!DOCTYPE html> |
	When I save
	And I run the test
	Then test result is Passed
	When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok
	Then workflow "WebRequestTestWF" is deleted as cleanup

Scenario: Test WF with RabbitMq Publish
	Given I have a workflow "RabbitMqPubTestWF"
	And "RabbitMqPubTestWF" contains RabbitMQPublish "TestRabbitMqPub" with source "testRabbitMQSource"
	And I save workflow "RabbitMqPubTestWF"
	Then the test builder is open with "RabbitMqPubTestWF"
	And I click New Test
	And a new test is added	
    And test name starts with "Test 1"
	And I Add "TestRabbitMqPub" as TestStep
	And I add new StepOutputs as 
	  	 | Variable Name | Condition | Value |
	  	 | [[result]]    | Contains  | Fail  |
	When I save
	And I run the test
	Then test result is Passed
	When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok
	Then workflow "RabbitMqPubTestWF" is deleted as cleanup

Scenario: Test WF with Calculate
	Given I have a workflow "CalculateTestWF"
	And "CalculateTestWF" contains an Assign "values1" as
      | variable | value |
      | [[a]]    | 1     |
      | [[b]]    | 5     |
	And "CalculateTestWF" contains Calculate "TestCalculate" with formula "Sum([[a]],[[b]])" into "[[result]]"
	And I save workflow "CalculateTestWF"
	Then the test builder is open with "CalculateTestWF"
	And I click New Test
	And a new test is added	
    And test name starts with "Test 1"
	And I Add "TestCalculate" as TestStep
	And I add new StepOutputs as 
	  	 | Variable Name | Condition | Value |
	  	 | [[result]]    | =         | 6     |		 
	When I save
	And I run the test
	Then test result is Passed
	When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok
	Then workflow "CalculateTestWF" is deleted as cleanup

Scenario: Test WF with Xpath
	Given I have a workflow "XPathTestWF"
	And "XPathTestWF" contains XPath \"XPathTest" with source "//XPATH-EXAMPLE/CUSTOMER[@id='2' or @type='C']/text()"
	And I save workflow "XPathTestWF"
	Then the test builder is open with "XPathTestWF"
	And I click New Test
	And a new test is added	
    And test name starts with "Test 1"
	And I Add "XPathTest" as TestStep
	And I add new StepOutputs as 
	  	 | Variable Name   | Condition | Value        |
	  	 | [[singleValue]] | =         | Mr.  Johnson |
	When I save
	And I run the test
	Then test result is Passed
	When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok
	Then workflow "XPathTestWF" is deleted as cleanup

Scenario: Test WF with SysInfo
	Given I have a workflow "SysInfoTestWF"
	And "SysInfoTestWF" contains Gather System Info "System info" as
	| Variable | Selected    |
	| [[a]]    | Date & Time |
	And I save workflow "SysInfoTestWF"
	Then the test builder is open with "SysInfoTestWF"
	And I click New Test
	And a new test is added	
    And test name starts with "Test 1"
	And I Add "System info" as TestStep
	And I add new StepOutputs as 
	  	 | Variable Name | Condition | Value |
	  	 | [[a]]         | Is Date   |       |
	When I save
	And I run the test
	Then test result is Passed
	When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok
	Then workflow "SysInfoTestWF" is deleted as cleanup

Scenario: Test WF with FormatNumber
	Given I have a workflow "FormatNumberTestWF"
	And "FormatNumberTestWF" contains Format Number "Fnumber" as 
	| Number  | Rounding Selected | Rounding To | Decimal to show | Result     |
	| 12.3412 | Up                | 3           | 2               | [[result]] |
	And I save workflow "FormatNumberTestWF"
	Then the test builder is open with "FormatNumberTestWF"
	And I click New Test
	And a new test is added	
    And test name starts with "Test 1"
	And I Add "Fnumber" as TestStep
	And I add new StepOutputs as 
	  	 | Variable Name | Condition | Value |
	  	 | [[result]]    | =         | 12.34 |
	When I save
	And I run the test
	Then test result is Passed
	When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok
	Then workflow "FormatNumberTestWF" is deleted as cleanup

Scenario: Test WF with Count Record
	Given I have a workflow "CountRecTestWF"
	And "CountRecTestWF&2Delete" contains an Assign "countrecordval1" as
	  | variable    | value |
	  | [[rec().a]] | 21    |
	  | [[rec().a]] | 22    |
	  | [[rec().a]] |       |
	  And "CountRecTestWF&2Delete" contains Count Record "Cnt1" on "[[rec()]]" into "[[result]]"
	And I save workflow "CountRecTestWF"
	Then the test builder is open with "CountRecTestWF"
	And I click New Test
	And a new test is added	
    And test name starts with "Test 1"
	And I Add "Cnt1" as TestStep
	And I add new StepOutputs as 
	  	 | Variable Name | Condition | Value |
	  	 | [[result]]    | =         | 3     |
	When I save
	And I run the test
	Then test result is Passed
	When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok
	Then workflow "CountRecTestWF" is deleted as cleanup

Scenario: Test WF with Lenght
	Given I have a workflow "LenghtTestWF"
	And "LenghtTestWF" contains an Assign "Rec To Convert" as
	  | variable    | value |
	  | [[rec().a]] | 1213  |
	  | [[rec().a]] | 4561  |
	  And "LenghtTestWF" contains Length "Len" on "[[rec(*)]]" into "[[result]]"
	And I save workflow "LenghtTestWF"
	Then the test builder is open with "LenghtTestWF"
	And I click New Test
	And a new test is added	
    And test name starts with "Test 1"
	And I Add "Len" as TestStep
	And I add new StepOutputs as 
	  	 | Variable Name | Condition | Value |
	  	 | [[result]]    | =         | 2     |
	When I save
	And I run the test
	Then test result is Passed
	When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok
	Then workflow "LenghtTestWF" is deleted as cleanup

Scenario: Test WF with Find Records
	Given I have a workflow "FindRecTestWF"
	 And "FindRecTestWF" contains an Assign "Record" as
      | variable     | value |
      | [[rec(1).a]] | 23    |
      | [[rec(2).a]] | 34    |
      | [[rec(3).a]]  | 10    |
	  And "FindRecTestWF" contains Find Record Index "FindRecord0" into result as "[[result]]"
	  | # | In Field    | # | Match Type | Match | Require All Matches To Be True | Require All Fields To Match |
	  | # | [[rec().a]] | 1 | =          | 34    | YES                            | NO                          |
	And I save workflow "FindRecTestWF"
	Then the test builder is open with "FindRecTestWF"
	And I click New Test
	And a new test is added	
    And test name starts with "Test 1"
	And I Add "FindRecord0" as TestStep
	And I add new StepOutputs as 
	  	 | Variable Name | Condition | Value |
	  	 | [[result]]    | =         | 2     |
	When I save
	And I run the test
	Then test result is Passed
	When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok
	Then workflow "FindRecTestWF" is deleted as cleanup

Scenario: Test WF with Delete Records
	Given I have a workflow "DeleteRecTestWF"
	And "DeleteRecTestWF" contains an Assign "Assign to delete" as
	  | variable    | value |
	  | [[rec().a]] | 50    |
	  And "DeleteRecTestWF" contains Delete "Delet1" as
	  | Variable   | result     |
	  | [[rec(1)]] | [[result]] |
      And I save workflow "DeleteRecTestWF"
	Then the test builder is open with "DeleteRecTestWF"
	And I click New Test
	And a new test is added	
    And test name starts with "Test 1"
	And I Add "Delet1" as TestStep
	And I add new StepOutputs as 
	  	 | Variable Name | Condition | Value   |
	  	 | [[result]]    | =         | Success |
	When I save
	And I run the test
	Then test result is Passed
	When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok
	Then workflow "DeleteRecTestWF" is deleted as cleanup

Scenario: Test WF with Unique Record
	Given I have a workflow "UniqueTestWF"
	 And "UniqueTestWF" contains an Assign "Records" as
	  | variable      | value |
	  | [[rs().row]]  | 10    |
	  | [[rs().data]] | 10    |
	  | [[rs().row]]  | 40    |
	  | [[rs().data]] | 20    |
	  | [[rs().row]]  | 20    |
	  | [[rs().data]] | 20    |
	  | [[rs().row]]  | 30    |
	  | [[rs().data]] | 40    |
	  And "UniqueTestWF" contains an Unique "Unique rec" as
	  | In Field(s)                  | Return Fields | Result           |
	  | [[rs(*).row]],[[rs(*).data]] | [[rs().row]]  | [[rec().unique]] |
	 And I save workflow "UniqueTestWF"
	Then the test builder is open with "UniqueTestWF"
	And I click New Test
	And a new test is added	
    And test name starts with "Test 1"
	And I Add "Unique rec" as TestStep
	And I add new StepOutputs as 
	  	 | Variable Name     | Condition | Value |
	  	 | [[rec(1).unique]] | =         | 10    |
	  	 | [[rec(2).unique]] | =         | 40    |
	  	 | [[rec(3).unique]] | =         | 20    |
	  	 | [[rec(4).unique]] | =         | 30    |
	When I save
	And I run the test
	Then test result is Passed
	When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok
	Then workflow "UniqueTestWF" is deleted as cleanup

Scenario: Test WF with Sort
	Given I have a workflow "SortTestWF"
	And "SortTestWF" contains an Assign "sortval5" as
	  | variable    | value |
	  | [[rs(1).a]] | 10    |	  	  
	  | [[rs(2).a]] | 20    |
	  And "SortTestWF" contains an Sort "sortRec1" as
	  | Sort Field  | Sort Order |
	  | [[rs(*).a]] | Backwards  |
	 And I save workflow "SortTestWF"
	Then the test builder is open with "SortTestWF"
	And I click New Test
	And a new test is added	
    And test name starts with "Test 1"
	And I Add "sortRec1" as TestStep
	And I add new StepOutputs as 
	  	 | Variable Name | Condition | Value |
	  	 | [[rs(1).a]]   | =         | 20    |
	  	 | [[rs(2).a]]   | =         | 10    |
	When I save
	And I run the test
	Then test result is Passed
	When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok
	Then workflow "SortTestWF" is deleted as cleanup

Scenario: Test WF with DateTime
	Given I have a workflow "DateTimeTestWF"
	And "DateTimeTestWF" contains Date and Time "AddDate" as
	| Input      | Input Format | Add Time | Output Format | Result     |
	| 12 03 2016 | dd mm yyyy   |          | yy mm dd      | [[result]] |
	And I save workflow "DateTimeTestWF"
	Then the test builder is open with "DateTimeTestWF"
	And I click New Test
	And a new test is added	
    And test name starts with "Test 1"
	And I Add "AddDate" as TestStep
	And I add new StepOutputs as 
	  	 | Variable Name | Condition | Value    |
	  	 | [[result]]    | =         | 16 03 12 |
	When I save
	And I run the test
	Then test result is Passed
	When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok
	Then workflow "DateTimeTestWF" is deleted as cleanup

Scenario: Test WF with DateTimeDiff
	Given I have a workflow "DateTimeDiffTestWF"	 	  
	And "DateTimeDiffTestWF" contains Date and Time Difference "DateTimedif" as
       | Input1     | Input2     | Input Format | Output In | Result     |
       | 02 03 2016 | 16 11 2016 | dd mm yyyy   | Days      | [[result]] |  
	And I save workflow "DateTimeDiffTestWF"
	Then the test builder is open with "DateTimeDiffTestWF"
	And I click New Test
	And a new test is added	
    And test name starts with "Test 1"
	And I Add "DateTimedif" as TestStep
	And I add new StepOutputs as 
	  	 | Variable Name | Condition | Value         |
		 | [[result]]      | =         | 259 |		 
	When I save
	And I run the test
	Then test result is Passed
	When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok
	Then workflow "DateTimeDiffTestWF" is deleted as cleanup

Scenario: Test WF with Unzip File
		Given I have a workflow "UnzipFileTestWF"		
		And "UnzipFileTestWF" contains an Create "Create1" as
		  | File or Folder                                          | If it exits | Username | Password | Result   |
		  | C:\ProgramData\Warewolf\Resources\FileToZipAndUnzip.txt | True        |          |          | [[res1]] |
		And "UnzipFileTestWF" contains an Zip "ZipFile" as
		  | File or Folder                                          | Destination                                                   | If it exits | Username | Password | Result        | Folders |
		  | C:\ProgramData\Warewolf\Resources\FileToZipAndUnzip.txt | C:\ProgramData\Warewolf\Resources\FileToZipAndUnzipZipped.zip | True        |          |          | [[ZipResult]] | True    |
		And "UnzipFileTestWF" contains an UnZip "UnZipFile" as
		  | File or Folder                                                | Destination                                                | If it exits | Username | Password | Result          | Folders |
		  | C:\ProgramData\Warewolf\Resources\FileToZipAndUnzipZipped.zip | C:\ProgramData\Warewolf\Resources\FileToZipAndUnzipZipped1 | True        |          |          | [[UnZipResult]] | True    |
		And I save workflow "UnzipFileTestWF"
		Then the test builder is open with "UnzipFileTestWF"
		And I click New Test
		And a new test is added	
		And test name starts with "Test 1"
		And I Add "UnZipFile" as TestStep
		And I add new StepOutputs as 
		| Variable Name   | Condition | Value   |
		| [[UnZipResult]] | =         | Success |
		When I save
		And I run the test
		Then test result is Passed
		When I delete "Test 1"
		Then The "DeleteConfirmation" popup is shown I click Ok
		Then workflow "UnzipFileTestWF" is deleted as cleanup
		
Scenario: Test WF with Zip File
		Given I have a workflow "ZipFileTestWF"		
		And "ZipFileTestWF" contains an Create "Create1" as
		  | File or Folder                                     | If it exits | Username | Password | Result   |
		  | C:\ProgramData\Warewolf\Resources\FileToZip.txt | True        |          |          | [[res1]] |
		And "ZipFileTestWF" contains an Zip "ZipFile" as
		  | File or Folder                                  | Destination                                  | If it exits | Username | Password | Result     | Folders |
		  | C:\ProgramData\Warewolf\Resources\FileToZip.txt | C:\ProgramData\Warewolf\Resources\Zipped.txt | True        |          |          | [[result]] | True    |
		And I save workflow "ZipFileTestWF"
		Then the test builder is open with "ZipFileTestWF"
		And I click New Test
		And a new test is added	
		And test name starts with "Test 1"
		And I Add "ZipFile" as TestStep
		And I add new StepOutputs as 
		| Variable Name | Condition | Value   |
		| [[result]]    | =         | Success |
		When I save
		And I run the test
		Then test result is Passed
		When I delete "Test 1"
		Then The "DeleteConfirmation" popup is shown I click Ok
		Then workflow "ZipFileTestWF" is deleted as cleanup

#Loop Constructs

Scenario: Test WF with ForEach which contains assign
		Given I have a workflow "ForEachWithAssignTestWF"		
		And "ForEachWithAssignTestWF" contains a Foreach "ForEachTest" as "NumOfExecution" executions "2"
	    And "ForEachTest" contains an Assign "MyAssign" as
	    | variable    | value |
	    | [[rec().a]] | Test  |
		And I save workflow "ForEachWithAssignTestWF"
		Then the test builder is open with "ForEachWithAssignTestWF"
		And I click New Test
		And a new test is added	
		And test name starts with "Test 1"
		And I Add "ForEachTest" as TestStep
		And I add new Children StepOutputs as 
		| Variable Name | Condition | Value |
		| [[rec(1).a]]  | =         | Test  |
		| [[rec(2).a]]  | =         | Test  |
		When I save
		And I run the test
		Then test result is Passed
		When I delete "Test 1"
		Then The "DeleteConfirmation" popup is shown I click Ok
		Then workflow "ForEachWithAssignTestWF" is deleted as cleanup

Scenario: Test WF with SelectAndApply which contains assign
		Given I have a workflow "SelectAndApplyWithAssignTestWF"		
		And "SelectAndApplyWithAssignTestWF" contains a SelectAndApply "SelectAndApplyTest" DataSource "[[rec(*).a]]" Alias "[[f]]"
	    And "SelectAndApplyTest" contains an Assign "MyAssign" as
	    | variable    | value |
	    | [[rec().a]] | Test  |
		And I save workflow "SelectAndApplyWithAssignTestWF"
		Then the test builder is open with "SelectAndApplyWithAssignTestWF"
		And I click New Test
		And a new test is added	
		And test name starts with "Test 1"
		And I Add "SelectAndApplyTest" as TestStep
		And I add new Children StepOutputs as 
		| Variable Name | Condition | Value |
		| [[rec(1).a]]  | =         | Test  |
		| [[rec(2).a]]  | =         | Test  |
		When I save
		And I run the test
		Then test result is Passed
		When I delete "Test 1"
		Then The "DeleteConfirmation" popup is shown I click Ok
		Then workflow "SelectAndApplyWithAssignTestWF" is deleted as cleanup

#Scripting
Scenario: Test WF with Cmd Script
	Given I have a workflow "CmdScriptTestWF"	
	And "SelectAndApplyWithAssignTestWF" contains a Cmd Script "testCmdScript" ScriptToRun "dir C:\ProgramData\Warewolf\Resources\*.xml" and result as "[[result]]"	
	And I save workflow "CmdScriptTestWF"
	Then the test builder is open with "CmdScriptTestWF"
	And I click New Test
	And a new test is added	
    And test name starts with "Test 1"
	And I Add "testCmdScript" as TestStep
	And I add new StepOutputs as 
	  	 | Variable Name | Condition | Value                       |
	  	 | [[result]]    | Contains  | Volume in drive C is System |   
	When I save
	And I run the test
	Then test result is Passed
	When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok
	Then workflow "CmdScriptTestWF" is deleted as cleanup
	
Scenario: Test WF with JavaScript
	Given I have a workflow "JavaScriptTestWF"	
	And "JavaScriptTestWF" contains a Java Script "testJavaScript" ScriptToRun "var myInt = Math.sqrt(49);return myInt;" and result as "[[result]]"	
	And I save workflow "JavaScriptTestWF"
	Then the test builder is open with "JavaScriptTestWF"
	And I click New Test
	And a new test is added	
    And test name starts with "Test 1"
	And I Add "testJavaScript" as TestStep
	And I add new StepOutputs as 
	  	 | Variable Name | Condition | Value |
	  	 | [[result]]    | =         | 7     |  
	When I save
	And I run the test
	Then test result is Passed
	When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok
	Then workflow "JavaScriptTestWF" is deleted as cleanup

Scenario: Test WF with Python
	Given I have a workflow "PythonTestWF"	
	  And "PythonTestWF" contains an Assign "MyAssign" as
	    | variable    | value                                                        |
	    | [[rec().a]] | return { '1': "one", '2': "two",}.get('7', "not one or two") |
	And "PythonTestWF" contains a Python "testPython" ScriptToRun "[[rec().a]]" and result as "[[result]]"		
	And I save workflow "PythonTestWF"
	Then the test builder is open with "PythonTestWF"
	And I click New Test
	And a new test is added	
    And test name starts with "Test 1"
	And I Add "testPython" as TestStep
	And I add new StepOutputs as 
	  	 | Variable Name | Condition | Value          |
	  	 | [[result]]    | =         | not one or two |
	When I save
	And I run the test
	Then test result is Passed
	When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok
	Then workflow "PythonTestWF" is deleted as cleanup

Scenario: Test WF with Ruby
	Given I have a workflow "RubyTestWF"	
	  And "RubyTestWF" contains an Assign "MyAssign" as
	    | variable    | value    |
	    | [[rec().a]] | sleep(5) |
	And "RubyTestWF" contains a Ruby "testRuby" ScriptToRun "[[rec().a]]" and result as "[[result]]"		
	And I save workflow "RubyTestWF"
	Then the test builder is open with "RubyTestWF"
	And I click New Test
	And a new test is added	
    And test name starts with "Test 1"
	And I Add "testRuby" as TestStep
	And I add new StepOutputs as 
	  	 | Variable Name | Condition | Value |
	  	 | [[result]]    | =         | 5     |
	When I save
	And I run the test
	Then test result is Passed
	When I delete "Test 1"
	Then The "DeleteConfirmation" popup is shown I click Ok
	Then workflow "RubyTestWF" is deleted as cleanup

