module.exports = {
  "/api": {
    target:
      process.env["services__api-service__https__0"] ||
      process.env["services__api-service__http__0"],
    secure: process.env["NODE_ENV"] !== "development",
  },
  "/hub": {
    target:
      process.env["services__api-service__https__0"] ||
      process.env["services__api-service__http__0"],
    secure: process.env["NODE_ENV"] !== "development",
    ws: true
  },
};
