# aspnet-versioning

Explore support for versioning in ASP.NET Web APIs using the `Asp.Versioning` package.

In the initial attempt to add versioning, we implemented api versioning using a query parameter
named `api-version` with date-based version values '2022-01-01' and '2023-01-01'.
Then we implemented one endpoint, /hello", that is defined for both API versions, and a
second endpoint, "goodbye", that is defined for only API version 2023-01-01.

So far:

- The `/hello' endpoint works correctly for both API versions.
- The `/goodbye` endpoint works correctly for API version 2023-01-01.
- An OpenAPI document is generated for both versions.

But there are some issues:

- Calling either endpoint without the `api-version` query parameter results in a 400 error
with no error message and no 'supported-api-versions' header.
- Calling either endpoint with an `api-version` query parameter that is not one of the defined
versions results in a 400 error with no error message and no 'supported-api-versions' header.
- The OpenAPI document for 2022-01-01 includes the `/goodbye` endpoint, which is not supported
for that version.
- The `api-version` query parameter is not included in the OpenAPI document for any endpoint
in either version.
