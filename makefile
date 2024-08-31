.DEFAULT_GOAL := help

help:
	@grep -E '^[a-zA-Z_-]+:.*?## .*$$' $(MAKEFILE_LIST) | sort | awk 'BEGIN {FS = ":.*?## "}; {printf "\033[36m%-30s\033[0m   %s\n", $$1, $$2}'

report: ## Generate a report of the current state of the project
	@echo "Generating report"

clean-rebuild: ## Clean and rebuild the project
	@echo "Cleaning and rebuilding the project"
	dotnet clean
	dotnet restore
	dotnet build

docker-image: ## Build the docker image
	@echo "Building the docker image"
	docker build -t dotnet-core-api .

docker-postgres: ## Run the postgres docker container
	@echo "Running the postgres docker container"
	docker run --name postgres -e POSTGRES_PASSWORD=postgres -d -p 5432:5432 postgres

post-script: ## Run the post-script to create the database
	@echo "Running the post-script to create the database"
	@bash ./Scripts/create_postgres_db.sh