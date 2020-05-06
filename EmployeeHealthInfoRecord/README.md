## Class library for Daily Health Monitor program

#### Data model

- `Record`
  - `GinNumber`, unique for each Employee
  - `Name`
  - `CheckDate`
  - `BodyTemperature`
  - `HasHubeiTravelHistory`
  - `HasSymptoms`
  - `Notes`
  - `createTime` (to be continued...)
  - `EditHistory` (to be continued...)
- `Records`
  - a `GinNumber` key-based dictionary
  - each key corresponds to a new `CheckDate`-`Record` key-value pair dictionary, which means each Employee could have records in different days.