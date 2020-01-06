WITH CTE AS
(
SELECT *,ROW_NUMBER() OVER (PARTITION BY NewsEntry.HeadlineUrl ORDER BY NewsEntry.HeadlineUrl) AS RN
FROM NewsEntry
)
DELETE FROM CTE WHERE RN<>1