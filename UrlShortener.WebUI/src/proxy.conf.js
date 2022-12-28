const PROXY_CONFIG = [
  {
    context: [
      "/api/Urls/",
    ],
    target: "https://localhost:7126",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
