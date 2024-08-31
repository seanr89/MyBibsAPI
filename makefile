.DEFAULT_GOAL := help


help:
	@grep -E '^[a-zA-Z_-]+:.*?## .*$$' $(MAKEFILE_LIST) | sort | awk 'BEGIN {FS = ":.*?## "}; {printf "\033[36m%-30s\033[0m   %s\n", $$1, $$2}'

install: ## Install npm dependencies for the api, admin, and frontend apps
	@echo "Installing Node dependencies"
	@npm install

report: ## Generate a report of the current state of the project
	@echo "Generating report"