# Use official Node.js image
FROM ghcr.io/quantium-enterprise/genaicore-claude-code/devcontainer-enterprise:latest

# Switch to root for system package installation
USER root

# Install additional tools and configure locales
RUN apt-get update && apt-get install -y \
    git \
    curl \
    vim \
    sudo \
    postgresql-client \
    locales \
    wget \
    ca-certificates \
    libc6 \
    libgcc-s1 \
    libgssapi-krb5-2 \
    libicu-dev \
    libssl3 \
    libstdc++6 \
    zlib1g \
    && sed -i '/en_US.UTF-8/s/^# //g' /etc/locale.gen \
    && locale-gen \
    && rm -rf /var/lib/apt/lists/*

# Set locale environment variables
ENV LANG=en_US.UTF-8 \
    LANGUAGE=en_US:en \
    LC_ALL=en_US.UTF-8

# Install .NET 10 SDK
RUN wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh \
    && chmod +x dotnet-install.sh \
    && ./dotnet-install.sh --channel 10.0 --install-dir /usr/share/dotnet \
    && rm dotnet-install.sh \
    && ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet

# Set .NET environment variables
ENV DOTNET_ROOT=/usr/share/dotnet \
    PATH="${PATH}:/usr/share/dotnet:/root/.dotnet/tools:/home/node/.dotnet/tools" \
    DOTNET_CLI_TELEMETRY_OPTOUT=1 \
    DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1

# Install pnpm and claude-cli globally
RUN npm install -g pnpm@9.0.0 @anthropic-ai/claude-code

# Give node user sudo access (for development only)
RUN echo "node ALL=(ALL) NOPASSWD:ALL" >> /etc/sudoers

# Set working directory
WORKDIR /workspace

# Fix permissions - ensure node user owns workspace
RUN mkdir -p /workspace/node_modules /workspace/.pnpm-store \
    && chown -R node:node /workspace

# Install .NET tools as node user
USER node
RUN dotnet tool install --global dotnet-ef \
    && dotnet tool install --global dotnet-aspnet-codegenerator

RUN git config --global core.editor vim

# Verify .NET installation
RUN dotnet --version