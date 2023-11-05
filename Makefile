.PHONY: run
.SILENT:

producer.rebuild:
	docker compose build producer

producer.run:
	docker compose run --rm producer

producer.gen:
	docker compose run --rm devtools /project/scripts/gen-models.sh

consumer.run:
	docker compose exec redpanda-0 rpk topic consume user-create

initialize: start
	docker compose exec redpanda-0 rpk topic create user-create
	docker compose run --rm devtools /project/scripts/update-schema.sh

devtools.shell:
	docker compose run --rm devtools

start:
	docker compose up -d

stop:
	docker compose stop

clean:
	docker compose run --rm devtools -c "dotnet clean"
	rm -rf kafka-user-producer-example.zip

destroy:
	docker compose down -v
	docker image prune -f

archive:
	rm -rf kafka-user-producer-example.zip
	git archive -o kafka-user-producer-example.zip HEAD
