# Use official .NET 10 SDK image
FROM mcr.microsoft.com/dotnet/sdk:10.0

# Create vscode user with same UID/GID as typical devcontainers
RUN groupadd --gid 1000 vscode \
    && useradd --uid 1000 --gid 1000 -m vscode \
    && apt-get update \
    && apt-get install -y sudo \
    && echo vscode ALL=\(root\) NOPASSWD:ALL > /etc/sudoers.d/vscode \
    && chmod 0440 /etc/sudoers.d/vscode

# Install additional tools and configure locales
RUN apt-get update && apt-get install -y \
    git \
    curl \
    vim \
    postgresql-client \
    locales \
    zsh \
    && sed -i '/en_US.UTF-8/s/^# //g' /etc/locale.gen \
    && locale-gen \
    && rm -rf /var/lib/apt/lists/*

# Set locale environment variables
ENV LANG=en_US.UTF-8 \
    LANGUAGE=en_US:en \
    LC_ALL=en_US.UTF-8

# Install Node.js (LTS) for tooling that may require it
RUN curl -fsSL https://deb.nodesource.com/setup_20.x | bash - \
    && apt-get install -y nodejs \
    && npm install -g @anthropic-ai/claude-code

# Install .NET tools globally
RUN dotnet tool install --global dotnet-ef \
    && dotnet tool install --global dotnet-aspnet-codegenerator

# Add .NET tools to PATH
ENV PATH="${PATH}:/root/.dotnet/tools:/home/vscode/.dotnet/tools"

# Set working directory
WORKDIR /workspace

# Fix permissions - ensure vscode user owns workspace
RUN mkdir -p /workspace \
    && chown -R vscode:vscode /workspace

# Switch to vscode user
USER vscode