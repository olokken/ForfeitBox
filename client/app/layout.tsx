import Providers from "./providers";
import "./globals.css";
import Navbar from "../components/client/navbar/Navbar";
import Sidebar from "../components/client/sidebar/Sidebar";
import PageContainer from "../components/client/PageContainer";
import { User } from "../data/models/User";
import Searchbar from "../components/server/inputfields/Searchbar";
import { MinimalBox } from "../data/models/Box";
import BoxCard from "../components/server/sidebar/BoxCard";
import { getUser } from "../data/api/server/user.api";

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
