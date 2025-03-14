This is a URL shortener application built using FastApi, PostgreSQL for database management, and Redis for caching frequently accessed data.

## Features

- **URL Shortening**: Converts long URLs into shorter, easier-to-share versions.
- **Custom Aliases**: Allows users to create custom short URLs.
- **Analytics**: Tracks the number of clicks on shortened URLs.
- **Caching with Redis**: Frequently accessed URLs are cached for faster retrieval.
- **Database Storage**: Stores all shortened URLs and their original mappings in PostgreSQL.

## Technologies Used

- **FastApi**: Web framework used for building the backend API.
- **PostgreSQL**: Relational database for storing URL data.
- **Redis**: Caching layer to enhance performance for high-traffic URLs.

## Prerequisites

- Python
- PostgreSQL
- Redis
- IDE (e.g., Pycharm or Visual Studio Code)
- Docker (optional, for containerization)

## Setup Instructions

1. **Clone the Repository**

   ```bash
   git clone https://github.com/AnimBadger/justshrt.git
   cd justshrt
   ```
