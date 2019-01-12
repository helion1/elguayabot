# ElGuayaBot
Simple yet Guayaba. Telegram Bot for my friends.

Production setup:
```bash
# create docker image
docker build -t elguayabot:latest .

# start docker-compose
docker-compose -f .docker/docker-compose.yml up -d
```

Development setup:
```bash
docker-compose -f .docker/docker-compose-development.yml up -d

```