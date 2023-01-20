import Providers from "./providers";
import "./globals.css";
import Navbar from "../components/client/navbar/Navbar";
import Sidebar from "../components/client/sidebar/Sidebar";
import PageContainer from "../components/client/PageContainer";
import { User } from "../models/User";
import { GET } from "./ajax";
import Searchbar from "../components/server/inputfields/Searchbar";
import { MinimalBox } from "../models/Box";
import BoxCard from "../components/server/sidebar/BoxCard";

async function getUser(): Promise<User> {
  return await GET("/User");
}

export default async function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  const user: User = await getUser();

  const boxCards = user.boxes.map((box: MinimalBox) => (
    <li key={box.boxId} className="">
      <BoxCard box={box}></BoxCard>
    </li>
  ));

  return (
    <html>
      <head />
      <body>
        <Providers>
          <Navbar searchbar={<Searchbar />}></Navbar>
          <Sidebar searchbar={<Searchbar />} boxCards={boxCards}></Sidebar>
          <PageContainer>{children}</PageContainer>
        </Providers>
      </body>
    </html>
  );
}
