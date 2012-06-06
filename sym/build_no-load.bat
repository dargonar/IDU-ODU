@echo off
@call symfony doctrine:build-sql
@call symfony doctrine:build-model
@call symfony doctrine:build-forms
@call symfony doctrine:build-filters