## Class library for Daily Health Monitor program

#### Data model

- `Record`
  - `GinNumber`(string), non-negative integer and unique for each Employee
  - `Name`(string)
  - `CheckDate`(DateTime), cannot be future date
  - `BodyTemperature`(double), positive number and range from 35 to 42 
  - `HasHubeiTravelHistory`(bool)
  - `HasSymptoms`(bool)
  - `Notes`(string)
  - `createTime`(DateTime) (to be continued...)
  - `EditHistory`(List\<DateTime\>) (to be continued...)
  - `Record` is **Suspect** if `HasSymptoms` is true or `HasHubeiTravelHistory` is true or `BodyTemperature` is larger than 37.3
- `Records`
  - a `GinNumber` key-based dictionary
  - each key corresponds to a new `CheckDate`-`Record` key-value pair dictionary, which means each Employee could have records in different days, but at most one record for one day.