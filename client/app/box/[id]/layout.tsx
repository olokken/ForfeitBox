import BoxTabs from "../../../components/server/tabs/BoxTabs";

export default function BoxLayout({
  children, // will be a page or nested layout
}: {
  children: React.ReactNode;
}) {
  return (
    <section>
      <BoxTabs />
      {children}
    </section>
  );
}
