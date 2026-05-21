import { createBrowserRouter, createRoutesFromElements, Route, RouterProvider } from "react-router-dom";
import MainLayout from "./layouts/MainLayout";
import MainPage from "./pages/MainPage";
import StartWorkoutPage from "./pages/WorkoutTemplatesPage";

const App = () => {

  const router = createBrowserRouter(
    createRoutesFromElements(
      <Route path="/" element={<MainLayout />}>
        <Route index element={<MainPage/>}/>
        <Route path="/templates" element={<StartWorkoutPage/>}/>
      </Route>
    )
  );

  return <RouterProvider router={router} />;
}

export default App