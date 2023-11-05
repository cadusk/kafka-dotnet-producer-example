#!/bin/sh

# Load environment variables for current project
source dev.env

# To programmatically create schemas for topics
# in Schema Registry, it's necessary to post a HTTP
# request with the desire schema and topic information.
echo "Registering schema for Topic"
curl -X POST \
    -H "Content-Type: application/vnd.schemaregistry.v1+json" \
    --data "{ \"schema\": $(jq -scM '. | @json' ./schemas/user.avsc)}" \
    "http://${EXAMPLE_SCHEMA_REGISTRY_URL}/subjects/${USER_CREATE_TOPIC}-value/versions"
