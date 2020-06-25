DELETE FROM public.movies where title not in ('Resident Evil', 'Batman Begins', 'Batman O Cavaleiro das Trevas', 'Vingadores Ultimato', 'Coringa', 'Deadpool 2');

INSERT INTO public.movies(title, status, year, release_date, "cast", overview, cover, created_at, updated_at) VALUES ('Carol', 'Disponível', 2020, '08/05/2020', '{"Carolina Castro", "Caio do Monte"}', 'Bla bla bla', 'carol.jpg', current_timestamp, current_timestamp);
INSERT INTO public.movies(title, status, year, release_date, "cast", overview, cover, created_at, updated_at) VALUES ('Carol2', 'Disponível', 2020, '08/05/2020', '{"Carolina Castro", "Caio do Monte"}', 'Bla bla bla', 'carol.jpg', current_timestamp, current_timestamp);
INSERT INTO public.movies(title, status, year, release_date, "cast", overview, cover, created_at, updated_at) VALUES ('Carol3', 'Disponível', 2020, '08/05/2020', '{"Carolina Castro", "Caio do Monte"}', 'Bla bla bla', 'carol.jpg', current_timestamp, current_timestamp);
INSERT INTO public.movies(title, status, year, release_date, "cast", overview, cover, created_at, updated_at) VALUES ('Testing', 'Disponível', 2020, '08/05/2020', '{"Carolina Castro", "Caio do Monte"}', 'Bla bla bla', 'carol.jpg', current_timestamp, current_timestamp);


SELECT id, title, status, year, release_date, "cast", overview, cover, created_at, updated_at
    FROM public.movies;