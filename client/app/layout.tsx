import Link from "next/link";
import "./globals.css";

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html>
      <head />
      <body>
        <nav>
          <Link href="/feed"> Feed</Link>
        </nav>
        {children}
      </body>
    </html>
  );
}
