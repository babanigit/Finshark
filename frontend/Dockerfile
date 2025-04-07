# Use nginx as base image
FROM nginx:alpine

# Set working directory
WORKDIR /usr/share/nginx/html

# Remove default nginx website
RUN rm -rf ./*

# Copy React build output (adjust the path if needed)
COPY dist/ ./

# Copy custom Nginx config to handle SPA routing (important for React Router)
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Expose port
EXPOSE 80

# Run nginx in foreground
CMD ["nginx", "-g", "daemon off;"]
