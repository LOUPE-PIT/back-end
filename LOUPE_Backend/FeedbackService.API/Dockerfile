FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine

# Create a new user
RUN adduser dotnetuser -D

# Impersonate into the new user
USER dotnetuser

# Switch to working directory
WORKDIR /home/dotnetuser/app

# Copy application files into container
COPY ./FeedbackService.API/build .
COPY ./FeedbackService.Api.Core .
COPY ./FeedbackService.DAL .

# Expose port for communication
EXPOSE 80

# Set container entrypoint to dotnet application
ENTRYPOINT ["dotnet", "FeedbackService.API.dll"]