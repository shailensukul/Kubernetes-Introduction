# FROM johnpapa/angular-cli as angular-built
# Using the above image allows us toskip the angular-cli install
FROM node:8.9-alpine as angular-built
WORKDIR /usr/src/app
RUN npm -g config set user root
RUN npm i -g @angular/cli
COPY . .

WORKDIR /usr/src/app/helloworldspa
RUN npm install --silent
RUN ng build --prod --build-optimizer

FROM nginx:alpine
LABEL author="John Papa"
COPY --from=angular-built /usr/src/app/helloworldspa/dist /usr/share/nginx/html

RUN rm /etc/nginx/nginx.conf
RUN rm /etc/nginx/conf.d/default.conf
COPY --from=angular-built /usr/src/app/helloworldspa/nginx.conf /etc/nginx/nginx.conf
COPY --from=angular-built /usr/src/app/helloworldspa/nginx.vh.default.conf /etc/nginx/conf.d/default.conf

EXPOSE 80 443
CMD [ "nginx", "-g", "daemon off;" ]