// @ts-check
const eslint = require('@eslint/js');
const tseslint = require('typescript-eslint');
const angular = require('angular-eslint');

const eslintPluginPrettierRecommended = require('eslint-plugin-prettier/recommended');

module.exports = tseslint.config(
  {
    files: ['**/*.ts'],
    languageOptions: {
      parserOptions: {
        project: 'tsconfig.json'
      }
    },
    ignores: [
      'package.json',
      'package-lock.json',
      'dist',
      'e2e/**',
      'karma.conf.js',
      'src/app/api/**'
    ],
    extends: [
      eslint.configs.recommended,
      ...tseslint.configs.recommended,
      ...tseslint.configs.stylistic,
      ...tseslint.configs.recommendedTypeChecked,
      ...angular.configs.tsRecommended,
      eslintPluginPrettierRecommended
    ],
    processor: angular.processInlineTemplates,
    rules: {
      '@angular-eslint/directive-selector': [
        'error',
        {
          type: 'attribute',
          prefix: 'po',
          style: 'camelCase'
        }
      ],
      '@angular-eslint/component-selector': [
        'error',
        {
          type: 'element',
          prefix: 'po',
          style: 'kebab-case'
        }
      ],
      '@typescript-eslint/no-unsafe-member-access': 'off',
      '@typescript-eslint/no-explicit-any': 'off',
      'prettier/prettier': [
        'error',
        {
          endOfLine: 'auto'
        }
      ],
      '@typescript-eslint/unbound-method': [
        'error',
        {
          ignoreStatic: true
        }
      ],
      'sort-imports': [
        'error',
        {
          ignoreCase: false,
          ignoreDeclarationSort: true,
          ignoreMemberSort: false,
          memberSyntaxSortOrder: ['none', 'all', 'multiple', 'single'],
          allowSeparatedGroups: false
        }
      ]
    }
  },
  {
    files: ['**/*.html'],
    extends: [
      ...angular.configs.templateRecommended,
      ...angular.configs.templateAccessibility,
      eslintPluginPrettierRecommended
    ],
    rules: {
      'prettier/prettier': ['error', { parser: 'angular' }]
    }
  }
);
