const PROXY_CONFIG = [
  {
    context: [
      "/api/Home/",
    ],
    target: "https://localhost:7126",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
