<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;
use Ramsey\Uuid\Uuid;

class EmployeeTestimonialSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        //
        DB::table('employee_testimonial')->insert([
            'employee_testimonial_id' => Uuid::uuid4(),
            'employee_id' => '9c1bbac4-9287-4dba-94c8-2cbc582e866d',
            'testimonial' => 'Robert is such a cool dude. A CRUD master on a different level!'
        ]);

        DB::table('employee_testimonial')->insert([
            'employee_testimonial_id' => Uuid::uuid4(),
            'employee_id' => 'a0513116-5192-4737-9fc8-d6b788e7a814',
            'testimonial' => 'Her name is Heff and he is the chief of CRUD!',
        ]);

        DB::table('employee_testimonial')->insert([
            'employee_testimonial_id' => Uuid::uuid4(),
            'employee_id' => 'a843a28e-497b-4264-a7e1-c47fbdf9ca53',
            'testimonial' => 'He does stuff that is very unconventional to that seemed stupid. However after a couple of CRUD sessions with him, I have realized that he is actually a gaddam genius!',
        ]);

        DB::table('employee_testimonial')->insert([
            'employee_testimonial_id' => Uuid::uuid4(),
            'employee_id' => 'bfeb449c-b436-49e4-9758-3c1010c49c71',
            'testimonial' => 'Bill is definitely one of the old school CRUD masters but don\'t be fooled. Traditional CRUD is proven by time and experience. Don\'t fix something that is not broken right?',
        ]);

        DB::table('employee_testimonial')->insert([
            'employee_testimonial_id' => Uuid::uuid4(),
            'employee_id' => 'e74c0517-66f0-44ea-8940-28b9ac689c67',
            'testimonial' => 'CRUD in the speed of light!',
        ]);
    }
}
