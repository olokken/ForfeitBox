import Providers from "./providers";
import "./globals.css";
import Navbar from "../components/navbar/Navbar";
import Sidebar from "../components/sidebar/Sidebar";
import PageContainer from "../components/PageContainer";

async function getForfeitBoxes() {}

async function createForfeitBox(name: string) {
  const payload = {
    name: name,
  };
  
  const response = fetch(`${process.env.BASE_URL}/case`, {
    method: "POST",
    body: JSON.stringify(payload),
  });
}

async function joinForfeitBox(code: string) {}

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html>
      <head />
      <body>
        <Providers>
          <Navbar></Navbar>
          <Sidebar></Sidebar>
          <PageContainer>{children}</PageContainer>
        </Providers>
      </body>
    </html>
  );
}
