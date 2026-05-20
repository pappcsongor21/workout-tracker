import { useQuery } from "@tanstack/react-query";
import WorkoutTemplateCard from "./components/WorkoutTemplateCard";
import type {WorkoutTemplate} from "./types/workoutTemplate";

const fetchWorkoutTemplates = async (): Promise<WorkoutTemplate[]> =>{
    const res = await fetch('/api/WorkoutTemplates');
    if(!res.ok){
      throw new Error('error fetching data')
    }
  return res.json();
}

const App = () => {

  const {data: workoutTemplates, isLoading, isError} = useQuery({
    queryKey: ['workoutTemplates'],
    queryFn: fetchWorkoutTemplates,
  })

  if(isLoading) {
    return (
      <div className="flex justify-center items-center h-screen text-2xl font-semibold">
        Loading workout templates...
      </div>
    )
  }

  if(isError) {
     <div className="flex justify-center items-center h-screen text-2xl text-red-500 font-bold">
      Cannot fetch workout template data, check the backend
     </div>
  }

  return (
    <div className="p-3 flex flex-wrap gap-6 justify-center">
      {workoutTemplates?.map((workoutTemplate) => (
        <WorkoutTemplateCard 
        key={workoutTemplate.id}
        workoutTemplate={workoutTemplate} />
      ))}
    </div>

  )
}

export default App