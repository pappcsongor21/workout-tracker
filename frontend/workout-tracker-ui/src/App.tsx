import { useEffect, useState } from "react"
import WorkoutTemplateCard from "./components/WorkoutTemplateCard";
import type {WorkoutTemplate} from "./types/workoutTemplate";

const App = () => {

  const [workoutTemplates, setWorkoutTemplates] = useState<WorkoutTemplate[]>([]);

  useEffect(()=>{
    const fetchWorkoutTemplates = async () =>{
      try {
        const res = await fetch('/api/WorkoutTemplates');
        const data: WorkoutTemplate[] = await res.json();
        setWorkoutTemplates(data);
      } catch (error) {
        console.log('error fetching data', error);
      }
    }

    fetchWorkoutTemplates();
  },[]);

  return (
    <div>
      {workoutTemplates.map((workoutTemplate) => (
        <WorkoutTemplateCard 
        key={workoutTemplate.id}
        workoutTemplate={workoutTemplate} />
      ))}
    </div>

  )
}

export default App