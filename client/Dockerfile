FROM node:lts 

EXPOSE 80

COPY ["package.json", "package-lock.json*"]

COPY . .

RUN npm install

RUN npm run build

CMD ["npm", "start" ]