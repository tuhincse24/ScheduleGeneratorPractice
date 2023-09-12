Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](ScheduleGeneratorPractice.Specs/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Generate event instances
	#Given the first number is 50
	#And the second number is 70
	#When the two numbers are added
	Then the event instance count should be 4

@mytag
Scenario: Generate event instances for multiple daysOfWeek
	#Given the first number is 50
	#And the second number is 70
	#When the two numbers are added
	Then event instance count should be
		| DateTimeOffsets |
		| 5               |
		| 1               |
		| 3               |

@mytag
Scenario: Add Online Store Products with Affiliate Codes
Then add products
| Url | AffilicateCode |
| /dp/B00TSUGXKE/ref=ods_gw_d_h1_tab_fd_c3 | affiliate3 |
| /dp/B00KC6I06S/ref=fs_ods_fs_tab_al | affiliate4 |
| /dp/B0189XYY0Q/ref=fs_ods_fs_tab_ts | affiliate5 |
| /dp/B018Y22C2Y/ref=fs_ods_fs_tab_fk | affiliate6 |