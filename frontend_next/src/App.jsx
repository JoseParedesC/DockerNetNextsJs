import Page from "./components/Common/Pages"
import Products from "./components/Productos/Products"
import Weather from "./components/Default/Weather"

function App() {

  const dataPages = [
    { PageName: "Default", PageCmp: Products },
    { PageName: "Productos", PageCmp: Weather }
  ]

  const classTailwind ="mx-auto flex max-w-sm items-center gap-x-4 rounded-xl bg-white p-6 shadow-lg outline outline-black/5 dark:bg-slate-800 dark:shadow-none dark:-outline-offset-1 dark:outline-white/10"

  return (
    <div style={{ padding: "2rem" }}>
      <h1>🚀 Frontend React con Nginx - JdParedesC</h1>
      <Page dataPages={dataPages}></Page>

      <div class="mx-auto flex max-w-sm items-center gap-x-4 rounded-xl bg-white p-6 shadow-lg outline outline-black/5 dark:bg-slate-800 dark:shadow-none dark:-outline-offset-1 dark:outline-white/10">
        <img class="size-12 shrink-0" src="/img/logo.svg" alt="ChitChat Logo" />
        <div>
          <div class="text-xl font-medium text-black dark:text-white">ChitChat</div>
          <p class="text-gray-500 dark:text-gray-400">You have a new message!</p>
        </div>
      </div>
    </div>
  );
}

export default App;
