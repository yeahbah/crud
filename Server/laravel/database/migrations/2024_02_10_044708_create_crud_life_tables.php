<?php

use GuzzleHttp\Psr7\DroppingStream;
use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;
use Illuminate\Support\Facades\DB;

return new class extends Migration
{
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        Schema::create('department', function (Blueprint $table) {
            $table->string('department_code', 5)->nullable(false);
            $table->string('name', 100)->nullable(false);
            $table->boolean('is_deleted');
        });

        Schema::create('employee', function (Blueprint $table) {
            $table->uuid('employee_id')->primary();
            $table->timestamp('updated_at')->nullable();
            $table->timestamp('created_at')->nullable(false)->default(DB::raw('CURRENT_TIMESTAMP'));
            $table->string('first_name', 50)->nullable(false);
            $table->string('last_name', 50)->nullable(false);
            $table->string('email', 100)->nullable();
            $table->string('phone_number', 15)->nullable();
            $table->date('birth_date');
            $table->string('department_code');
            $table->boolean('is_deleted')->default(false);
        });

        Schema::create('project', function (Blueprint $table) {
            $table->uuid('project_id')->primary();
            $table->timestamp('updated_at')->nullable();
            $table->timestamp('created_at')->nullable(false)->default(DB::raw('CURRENT_TIMESTAMP'));
            $table->string('name', 100)->nullable(false);
            $table->string('description', 2000);
            $table->boolean('is_deleted')->default(false);
            $table->foreignUuid('created_by_employee_id')->references('employee_id')->on('employee');
            $table->foreignUuid('updated_by_employee_id')->nullable()->references('employee_id')->on('employee');
        });

        Schema::create('employee_project', function (Blueprint $table) {
            $table->foreignUuid('employee_id')->references('employee_id')->on('employee');
            $table->foreignUuid('project_id')->references('project_id')->on('project');
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('employee_project');
        Schema::dropIfExists('project');
        Schema::dropIfExists('employee');
        Schema::dropIfExists('department');
    }
};
