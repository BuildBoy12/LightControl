# Light Control
A simple EXILED Plugin to set default color for certain rooms and/or zones

# Config
Name | Type | Description | Default
---- | ---- | ----------- | -------
is_enabled | bool | Should the plugin be enabled? | true
rooms | List | What Rooms should have what Color, See [Room Example Config](https://github.com/Marco15453/LightControl#room-example-config) for the Format (If empty it will be ignored) | Empty
zones | List | What Zones should have what Color, See [Zone Example Config](https://github.com/Marco15453/LightControl#zone-example-config) for the Format (If empty it will be ignored) | Empty

# Default Config
```yml
light_control:
  # Should the plugin be enabled?
  is_enabled: true
  # What Rooms should have what Color, See Room Example Config for the Format (If empty it will be ignored)
  rooms: []
  # What Zones should have what Color, See Zone Example Config for the Format (If empty it will be ignored)
  zones: []
```

# Room Example Config
All rooms can be found [Here](https://exiled-team.github.io/EXILED/api/Exiled.API.Enums.RoomType.html)
```yml
light_control:
  # Should the plugin be enabled?
  is_enabled: true
  # What Rooms should have what Color, See Room Example Config for the Format (If empty it will be ignored)
  rooms:
  - room: LczClassDSpawn
    color:
      red: 0
      green: 255
      blue: 0
      alpha: 255
  - room: LczCurve
    color:
      red: 0
      green: 255
      blue: 0
      alpha: 255
  # What Zones should have what Color, See Zone Example Config for the Format (If empty it will be ignored)
  zones: []
```

# Zone Example Config
All zones can be found [Here](https://exiled-team.github.io/EXILED/api/Exiled.API.Enums.ZoneType.html)
```yml
light_control:
  # Should the plugin be enabled?
  is_enabled: true
  # What Rooms should have what Color, See Room Example Config for the Format (If empty it will be ignored)
  rooms: []
  # What Zones should have what Color, See Zone Example Config for the Format (If empty it will be ignored)
  zones:
  - zone: LightContainment
    color:
      red: 0
      green: 255
      blue: 0
      alpha: 255
  - zone: HeavyContainment
    color:
      red: 0
      green: 255
      blue: 0
      alpha: 255
```