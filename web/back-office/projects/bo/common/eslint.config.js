// @ts-check
const tseslint = require("typescript-eslint");
const rootConfig = require("../../../eslint.config.js");

module.exports = tseslint.config(
  ...rootConfig,
  {
    languageOptions: {
      parserOptions: {
        project: 'tsconfig.lib.json'
      }
    }
  },
  {
    files: ["**/*.ts"],
    rules: {
      "@angular-eslint/directive-selector": [
        "error",
        {
          type: "attribute",
          prefix: "common",
          style: "camelCase",
        },
      ],
      "@angular-eslint/component-selector": [
        "error",
        {
          type: "element",
          prefix: "common",
          style: "kebab-case",
        },
      ],
    },
  },
  {
    files: ["**/*.html"],
    rules: {},
  }
);