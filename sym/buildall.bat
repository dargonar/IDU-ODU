@echo off
REM del /Q lib\filter\doctrine\base\*
REM del /Q lib\form\doctrine\base\*
REM del /Q lib\model\doctrine\base\*

@call symfony doctrine:build --all
@call symfony doctrine:data-load