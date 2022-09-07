FROM nginxinc/nginx-unprivileged:1.17-alpine

COPY nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 80