## Overview
	- API Project using REDIS with Scrutor to simulate calls to an external service when value expired on cache.

## Prerequisites
	- [Rancher desktop](https://rancherdesktop.io/) installed in order to use docker

## Running the project:
	1. On secrets, add key "RedisConnection" with value "localhost:6379"
	2. Run rancher desktop
	3. Run following command: "docker-compose -f .\docker-compose.yml up"
	4. Call API with any GUID Id and check cache on http://localhost:8081/
		4.1 After 20 seconds the key will be removed because it expired

References:
- [Scrutor](https://www.code4it.dev/blog/caching-decorator-with-scrutor/)
- https://github.com/dhukke/BackgroundScrutor
