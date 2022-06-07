const {defaults} = require('jest-config');

module.exports = {
  preset: "jest-preset-angular",
  testEnvironment: "jsdom",
  testEnvironmentOptions: {
    "browsers": [
      "chrome",
      "firefox",
      "safari"
    ]
  },
  testRegex: "(/__tests__/.*|(\\.|/)(test|spec))\\.(jsx?|tsx?)$",
  testPathIgnorePatterns: ["/dist/", "/coverage", "/node_modules/"],
  moduleFileExtensions: ["ts", "js", "json", "node"],
  collectCoverage: false,
  globals: {
    "ts-jest": {
      diagnostics: {
        ignoreCodes: [151001],
      },
      tsconfig: "<rootDir>/src/tsconfig.spec.json",
    },
  },
  setupFilesAfterEnv: ["<rootDir>/setupJest.ts"],
  globalSetup: "jest-preset-angular/global-setup",
};
