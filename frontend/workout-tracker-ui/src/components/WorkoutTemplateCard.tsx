import { useState } from "react"
import type { WorkoutTemplateCardProps } from "../types/workoutTemplate"
import TemplateExerciseBlock from "./TemplateExerciseBlock"
import { FaChevronDown, FaChevronUp } from "react-icons/fa6";

const WorkoutTemplateCard = ({workoutTemplate}:WorkoutTemplateCardProps) => {
  const [detailedView, setDetailedView] = useState(false);

  return (
    <section className="py-4 w-full flex justify-center">

      <div className="relative group w-xl transition duration-150 ease-in-out hover:scale-102">
        
        <div className="relative z-10 w-full shadow-lg overflow-hidden rounded-xl">
          <div>
            <div
              style={{ backgroundColor: workoutTemplate.colorHex }} 
              className="text-center text-white text-4xl font-bold py-5 tracking-wide"
            >
              <p className="cursor-default">{workoutTemplate.name}</p>
            </div>
            
            <div className="flex flex-col w-full text-center">
              {detailedView && workoutTemplate.exercises.map((exercise) => (
                <TemplateExerciseBlock key={exercise.id} templateExercise={exercise} />
              ))}
            </div>
          </div>
        </div>

        <button className="
        absolute z-0 left-0 top-full -mt-6 w-full bg-slate-400 text-white 
        text-md pt-3 pb-0.5 text-center rounded-b-xl shadow-lg 
        invisible opacity-0 transition-all delay-100 duration-200 
        group-hover:visible group-hover:opacity-100 group-hover:translate-y-3 
        cursor-pointer"
        onClick={()=>{
          setDetailedView(!detailedView)
        }}>
          <div className="flex justify-center">
            {detailedView?<FaChevronUp className="text-xl text-gray-700" />
            :<FaChevronDown className="text-xl text-gray-700" />}
          </div>
        </button>

      </div>
    </section>
  )
}

export default WorkoutTemplateCard