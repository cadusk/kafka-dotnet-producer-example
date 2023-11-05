#!/bin/sh

# Load environment variables for current project
source dev.env

# Redpanda offers a command line tool for creating topics, so
# we use it.
# It might not be true for other services and this procedure 
# will have to be adjusted.
echo "Creating topic"
docker compose exec redpanda-0 rpk topic create ${USER_CREATE_TOPIC}
