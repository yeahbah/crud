<div>
    <!-- Banner -->
    <section id="banner">
        <div class="inner">
            <header>
                <h1>Create, Read, Update, Delete</h1>
                <p>
                    Life is too short. Start your CRUD life today!
                </p>
            </header>
            <a href="#main" class="button big scrolly">Learn More</a>
        </div>
    </section>

    <!-- Main -->
    <div id="main">
        <!-- Section -->
        <section class="wrapper style2">
            <div class="inner">
                <div class="flex-2 flex">
                    <div class="col col2">
                        <h3>Take your CRUD to the next level!</h3>
                        <p>
                            We at CRUD Life are dedicated to Create, Read, Update and Delete
                            stuff. These actions are the basic of the Internet. Can you imagine
                            not having the internet? That would be awful. It's not the life
                            I would want to live!
                        </p>
                        <p>
                            CRUD is life. Start your CRUD Life today! </p>
                        <a href="#" class="button">Learn More</a>
                    </div>
                    <div class="col col1 first">
                        <div class="image round fit">
                            <a href="generic.html" class="link"><img src="images/pic02.jpg" alt="" width="320" height="320" /></a>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- Section -->
        <section class="wrapper style1">
            <div class="inner">
                <!-- 2 Columns -->
                <!-- <div class="flex-2 flex">
                    <div class="col col1">
                        <div class="image round fit">
                            <a href="generic.html" class="link"><img src="images/pic01.jpg" alt="" width="320" height="320" /></a>
                        </div>
                    </div> -->
                <!-- <div class="col col2"> -->
                <h2>Our CRUD Projects</h2>


                <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">

                    <!-- <div class="carousel-indicators">
                        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
                        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
                    </div> -->
                    <div class="carousel-inner">
                        <div class="carousel-item active" style="padding-top: 50px">

                            <h4 style="text-align: center;">{{ $projects->first()->name }}</h4>
                            <p>{{ $projects->first()->description }}</p>
                            <div style="text-align: center;"><a href="/projects/{{ $projects->first()->project_id }}" class="button">Learn More</a></div>
                        </div>
                        @foreach ($projects->skip(1) as $project)
                        <div class="carousel-item" style="padding-top: 50px">

                            <h4 style="text-align: center;">{{ $project->name }}</h4>
                            <p>{{ $project->description }}</p>
                            <div style="text-align: center;"><a href="/projects/{{ $project->project_id }}" class="button">Learn More</a></div>
                        </div>
                        @endforeach
                    </div>

                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                </div>

                <!-- </div> -->
                <!-- </div> -->
            </div>
        </section>

        <!-- Section -->
        <section class="wrapper style1">
            <div class="inner">
                <header class="align-center">
                    <h2>CRUD Masters</h2>
                    <!-- <p>
                        Cras sagittis turpis sit amet est tempus, sit amet
                        consectetur purus tincidunt.
                    </p> -->
                </header>
                <div class="flex-3 flex">

                    @foreach($employees->take(2) as $employee)
                    <div class="col align-center">
                        <div class="image round">
                            <img src="images/avatar-{{ $employee->last_name }}.jpg" alt="" width="200" height="200" />
                        </div>
                        <h3>{{ $employee->first_name }} {{ $employee->last_name }}</h3>
                        <p>
                            {{ $employee->testimonials->first()->testimonial }}
                        </p>

                    </div>
                    @endforeach

                </div>

                <div class="flex-3 flex" style="margin-top: 100px">

                    @foreach($employees->skip(2) as $employee)
                    <div class="col align-center" style="margin: 10px">
                        <div class="image round">
                            <img src="images/avatar-{{ $employee->last_name }}.jpg" alt="" width="200" height="200" />
                        </div>
                        <h3>{{ $employee->first_name }} {{ $employee->last_name }}</h3>
                        <p>
                            {{ $employee->testimonials->first()->testimonial }}
                        </p>

                    </div>
                    @endforeach

                </div>
            </div>
        </section>
    </div>
</div>